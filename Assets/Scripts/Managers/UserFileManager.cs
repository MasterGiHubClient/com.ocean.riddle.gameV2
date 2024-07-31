using System;
using System.IO;
using UnityEngine;

namespace Managers
{
    public class UserFileManager
    {
        private string _userPhotoPath = $"{Application.persistentDataPath}/photo.png";
        public Sprite UserPhoto { get; private set; }

        public event Action OnPhotoChange;
        
        public UserFileManager()
        {
            LoadUserPhoto();
        }

        public void PickUserPhoto()
        {
            NativeFilePicker.PickFile(PickPhotoCallback, "image/*");
        }

        private void LoadUserPhoto()
        {
            if (!File.Exists(_userPhotoPath))
                return;
            
            var texture = new Texture2D(1, 1);
            texture.LoadImage(File.ReadAllBytes(_userPhotoPath));
            UserPhoto = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(texture.width / 2, texture.height / 2)
            );
            
            OnPhotoChange?.Invoke();
        }

        private void PickPhotoCallback(string path)
        {
            if (path is null)
                return;
            
            if (UserPhoto != null)
                File.Delete(_userPhotoPath);
            
            File.Copy(path, _userPhotoPath);
            LoadUserPhoto();
        }
    }
}