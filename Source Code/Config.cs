using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace Narkomania
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;
        
        public int healthPercent { get; set; } = 200;

        public string hintUseAd { get; set; } = "Вы использовали шприц со странным веществом.";
        
        public string hintUseScp500 { get; set; } = "Вы использовали таблетки от запора.";
        
        public string hintPickUpAd { get; set; } = "Вы подобрали шприц со странным веществом. На обороте написанно .......";
        
        public string hintPickUpScp500 { get; set; } = "Вы подобрали таблетки от запора...";
        
        public string rankNm1 { get; set; } = "Неадекват...";
        
        public string rankNm2 { get; set; } = "Четкий пацан";
        
        public string bc1 { get; set; } = "У вас начались приступы!";
        
        public string bc2 { get; set; } = "Вы стали Четким Пацаном!";
    }
}