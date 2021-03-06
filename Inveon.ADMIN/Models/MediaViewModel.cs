﻿using System;
using Inveon.ADMIN.Helpers;

namespace Inveon.ADMIN.Models
{
    public class MediaViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        private string _Path { get; set; }

        public string Path
        {
            get => _Path;
            set => _Path = ReadSettingsHelper.ImagePath().Replace("~",string.Empty) + value;
        }

        public int NodeOrder { get; set; }
    }
}