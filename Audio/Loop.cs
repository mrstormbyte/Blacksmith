using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Blacksmith
{
    /// <summary>
    /// Зацикленный Addressable аудиоклип. Выгружается из памяти при паузе.
    /// </summary>
    public class Loop : MonoBehaviour
    {
        #region ПОЛЯ
        //Луп
        [SerializeField, Header("Луп")]
        private AssetReferenceAudioClip _audioClip = null;

        //Группа миксера
        [SerializeField, Header("Группа аудиомиксера")]
        private AudioMixerGroup _audioMixerGroup = null;
        //Воспроизвести при старте?
        [SerializeField, Header("Воспроизвести при старте?")]
        private bool _playOnStart = false;

        //Аудиоресурс
        private AudioSource _audioSource = null;
        //Результат загрузки ассета
        private AsyncOperationHandle _asyncOperationHandle;

        //Время паузы лупа для воспроизведения с того же места
        private float _playbackTime = 0;
        #endregion


        #region СВОЙСТВА
        /// <summary>
        /// Воспроизводится ли луп?
        /// </summary>
        public bool isPlaying => _audioSource.isPlaying;

        /// <summary>
        /// Громкость
        /// </summary>
        public float volume
        {
            get => _audioSource.volume;
            set => _audioSource.volume = Mathf.Clamp(value, 0, 1);
        }

        /// <summary>
        /// Скорость воспроизведения лупа
        /// </summary>
        public float pitch 
        {
            get => _audioSource.pitch;
            set => _audioSource.pitch = value;
        }
        #endregion


        #region MONOBEHAVIOR
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            //Устанавливаем группу аудиомиксера
            _audioSource.outputAudioMixerGroup = _audioMixerGroup;
            //Устанавливаем зацикливание звука
            _audioSource.loop = true;
            //Выключаем аудиоресурс
            _audioSource.enabled = false;
            //Устанавливаем игнорирование паузы
            _audioSource.ignoreListenerPause = Game.Audio.IsSoundIgnoreTimeAndPause(_audioSource);
        }
        private void Start()
        {
            if(_playOnStart)
                Play();
        }
        #endregion


        #region ПУБЛИЧНЫЕ ФУНКЦИИ
        /// <summary>
        /// Воспроизвести луп. Воспроизведение не начнётся, если луп уже проигрывается 
        /// </summary>
        public void Play()
        {
            if(_audioSource.isPlaying)
                return;

            //Включаем аудиоресурс
            _audioSource.enabled = true;

            //Если ассет уже загружен
            if(_asyncOperationHandle.IsValid()) {
                SetTimeAndPlay();
            } else {
                //Загружаем ассет
                Addressables.LoadAssetAsync<AudioClip>(_audioClip).Completed += handle =>
                {
                    if(handle.Status == AsyncOperationStatus.Succeeded) {
                        //Воспроизводим луп, если он не был остановлен во время загрузки
                        if(_audioSource.enabled) {
                            _asyncOperationHandle = handle;
                            _audioSource.clip = handle.Result;
                            SetTimeAndPlay();
                        //Если во время загрузки луп был остановлен, выгружаем ассет
                        } else {
                            Addressables.Release(handle);
                        }
                    }
                };
            }
        }
        /// <summary>
        /// Воспроизвести луп c начала
        /// </summary>
        public void PlayFromBegining()
        {
            //Останавливаем луп
            _audioSource.Pause();
            //Устанавливаем воспроизведение на начало
            _playbackTime = 0;
            //Воспроизводим луп
            Play();
        }
        /// <summary>
        /// Остановить луп
        /// </summary>
        public void Pause()
        {
            if(!_audioSource.isPlaying)
                return;

            //Останавливаем луп
            _audioSource.Pause();
            //Запоминаем время
            _playbackTime = _audioSource.time;
            //Отключаем аудиоресурс. Это необходимо для предотвращения воспроизведения лупа, если он загрузился после паузы
            _audioSource.enabled = false;

            if(!_asyncOperationHandle.IsValid())
                return;

            //Выгружаем ассет
            Addressables.Release(_asyncOperationHandle);
        }
        #endregion


        #region ПРИВАТНЫЕ МЕТОДЫ И ФУНКЦИИ
        //Устанавливаем время и воспроизводим луп
        private void SetTimeAndPlay()
        {
            _audioSource.time = _playbackTime;
            _audioSource.Play();
        }
        #endregion
    }
}

