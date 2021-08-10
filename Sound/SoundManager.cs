using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Sound
{
	public class SoundManager
	{
		private SoundEffect _currentSound;
		private float _currentSoundTime = 0f;
		private bool _soundIsPlaying;
		private bool _looping;
		public SoundManager()
		{
			_looping = false;
		}
		public SoundManager(bool looping)
		{
			_looping = looping;
		}
		public void PlaySound(SoundEffect sound, float volume, float pitch = 0f)
		{
			_currentSoundTime = (float)sound.Duration.TotalSeconds;
			sound.Play(volume, pitch, 0);
			_soundIsPlaying = true;
			_currentSound = sound;

		}
		public void Update(float deltaTime)
		{
			if (_soundIsPlaying && _currentSoundTime > 0)
			{
				_currentSoundTime -= deltaTime;
			}
			if (_looping && _currentSoundTime <= 0)
			{
				PlaySound(_currentSound, 0.1f);
			}
				
		}
		public float GetCurrentSoundDuration()
		{
			if (_currentSound != null)
				return (float)_currentSound.Duration.TotalSeconds;
			return 0f;
		}
	}
}
