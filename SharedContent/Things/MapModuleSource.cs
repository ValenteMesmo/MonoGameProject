using System.Collections.Generic;

namespace MonoGameProject
{
    public static class MapModuleSource
    {
        public static List<MapModuleInfo> GetAll()
        {
            var result = new List<MapModuleInfo>();

            result.AddRange(Bot());
            result.AddRange(Mid());
            result.AddRange(Top());

            result.AddRange(TransitionBotMid());
            result.AddRange(TransitionMidBot());

            result.AddRange(TransitionMidTop());
            result.AddRange(TransitionTopMid());

            result.AddRange(TransitionBotTop());
            result.AddRange(TransitionTopBot());

            return result;
        }

        private static List<MapModuleInfo> Bot()
        {
            var top = false;
            var mid = false;
            var bot = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2222222222222222")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0jjj000000000000"//E
                    , "0000000000000000"//E
                    , "2^^^^^^^^^^^^^^2")
            };
        }

        private static List<MapModuleInfo> Mid()
        {
            var top = false;
            var mid = true;
            var bot = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2222222222222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2^^^^22^^^^2^^^2"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "======00000====="//E
                    , "======00000====="//E
                    , "2222220000022222"//
                    , "111111^^^^^11111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> Top()
        {
            var top = true;
            var mid = false;
            var bot = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2222222222222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "11============11"//
                    , "1==============1"//E
                    , "1====000000====1"//E
                    , "==000000000000==")
            };
        }

        private static List<MapModuleInfo> TransitionBotMid()
        {
            var botEntry = true;
            var midEntry = false;
            var topEntry = false;
            var botExit = false;
            var midExit = true;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000022222222"//
                    , "0000000011111111"//
                    , "0000000011111111"//
                    , "0000222211111111"//
                    , "0000111111111111"//E
                    , "0000111111111111"//E
                    , "2222111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionMidBot()
        {
            var botEntry = false;
            var midEntry = true;
            var topEntry = false;
            var botExit = true;
            var midExit = false;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2222000000000000"//
                    , "1111000000000000"//
                    , "1111000000000000"//
                    , "1111000000000000"//
                    , "1111222222200000"//E
                    , "1111111111100000"//E
                    , "1111111111122222")
            };
        }

        private static List<MapModuleInfo> TransitionMidTop()
        {
            var botEntry = false;
            var midEntry = true;
            var topEntry = false;
            var botExit = false;
            var midExit = false;
            var topExit = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000222222"//
                    , "0000000000111111"//
                    , "0000000000111111"//
                    , "0000222222111111"//
                    , "0000111111111111"//E
                    , "0000111111111111"//E
                    , "2222111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionTopMid()
        {
            var botEntry = false;
            var midEntry = false;
            var topEntry = true;
            var botExit = false;
            var midExit = true;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2222000000000000"//
                    , "1111000000000000"//
                    , "1111000000000000"//
                    , "1111222222000000"//
                    , "1111111111000000"//E
                    , "1111111111000000"//E
                    , "1111111111222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionBotTop()
        {
            var botEntry = true;
            var midEntry = false;
            var topEntry = false;
            var botExit = false;
            var midExit = false;
            var topExit = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000002"//
                    , "0000000000000001"//
                    , "0000000000000001"//
                    , "0000000000002221"//
                    , "0000000000001111"//E
                    , "0000000000001111"//E
                    , "0000000022221111"//
                    , "0000000011111111"//
                    , "0000000011111111"//
                    , "0000222211111111"//
                    , "0000111111111111"//E
                    , "0000111111111111"//E
                    , "2222111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionTopBot()
        {
            var botEntry = false;
            var midEntry = false;
            var topEntry = true;
            var botExit = true;
            var midExit = false;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2000000000000000"//
                    , "1000000000000000"//
                    , "1000000000000000"//
                    , "1222000000000000"//
                    , "1111000000000000"//E
                    , "1111000000000000"//E
                    , "1111222200000000"//
                    , "1111111100000000"//
                    , "1111111100000000"//
                    , "1111111122222000"//
                    , "1111111111111000"//E
                    , "1111111111111000"//E
                    , "1111111111111222")
                ,new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "2000000000000000"//
                    , "1000000000000000"//
                    , "1000000000000000"//
                    , "1000000000000000"//
                    , "1000000000000000"//E
                    , "1000011000000000"//E
                    , "1000000000000000"//
                    , "1000000000011000"//
                    , "1000000000000000"//
                    , "1000000000000000"//
                    , "10a0000000000000"//E
                    , "1000000000000000"//E
                    , "1222222222222222")
            };
        }
    }

    public static class MapCaveModuleSource
    {
        public static List<MapModuleInfo> GetAll()
        {
            var result = new List<MapModuleInfo>();

            result.AddRange(Bot());
            result.AddRange(Mid());
            result.AddRange(Top());

            result.AddRange(TransitionBotMid());
            result.AddRange(TransitionMidBot());

            result.AddRange(TransitionMidTop());
            result.AddRange(TransitionTopMid());

            result.AddRange(TransitionBotTop());
            result.AddRange(TransitionTopBot());

            return result;
        }

        private static List<MapModuleInfo> Bot()
        {
            var top = false;
            var mid = false;
            var bot = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "================"//E
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "================"//E
                    , "================"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "1==============="//E
                    , "1====00===00===="//E
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "1====00===00===="//E
                    , "1====00===00===="//E
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "1====00===00===="//
                    , "================"//E
                    , "================"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> Mid()
        {
            var top = false;
            var mid = true;
            var bot = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "================"//E
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//E
                    , "================"//E
                    , "2222222222222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "================"//E
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//E
                    , "================"//E
                    , "2^^^^22^^^^2^^^2"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "222222=====22222"//
                    , "111111^^^^^11111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "====11111111===="//E
                    , "====11111111===="//E
                    , "====11111111===="//
                    , "====11111111===="//
                    , "====11111111===="//
                    , "====11111111===="//
                    , "====11111111===="//E
                    , "====11111111===="//E
                    , "2===11111111===2"//
                    , "1===11111111===1"//
                    , "1===11111111===1"//
                    , "1==============1"//
                    , "1==============1"//E
                    , "1==============1"//E
                    , "1222222222222221")
            };
        }

        private static List<MapModuleInfo> Top()
        {
            var top = true;
            var mid = false;
            var bot = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "2222222222222222"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000000")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "====1==========="//E
                    , "====1==========="//E
                    , "2===1===22222222"//
                    , "1===1==========1"//
                    , "1===1==========1"//
                    , "1===12222222===1"//
                    , "1===1==========1"//E
                    , "1===1==========1"//E
                    , "1===1===22222221"//
                    , "1===1==========1"//
                    , "1===1==========1"//
                    , "1===12222222===1"//
                    , "1==============1"//E
                    , "1==============1"//E
                    , "1222222222222221")
            };
        }

        private static List<MapModuleInfo> TransitionBotMid()
        {
            var botEntry = true;
            var midEntry = false;
            var topEntry = false;
            var botExit = false;
            var midExit = true;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "=00==00==00==00="//E
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00==00="//
                    , "=00==00==00====="//E
                    , "=00==00==00====="//E
                    , "=00==00==00===22"//
                    , "=00==00==00===11"//
                    , "=00==00=====2211"//
                    , "=00==00=====1111"//
                    , "==========221111"//E
                    , "==========111111"//E
                    , "2222222222111111")
            };
        }

        private static List<MapModuleInfo> TransitionMidBot()
        {
            var botEntry = false;
            var midEntry = true;
            var topEntry = false;
            var botExit = true;
            var midExit = false;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//E
                    , "================"//E
                    , "2222============"//
                    , "1111============"//
                    , "1111============"//
                    , "1111============"//
                    , "11112222222====="//E
                    , "11111111111====="//E
                    , "1111111111122222")
            };
        }

        private static List<MapModuleInfo> TransitionMidTop()
        {
            var botEntry = false;
            var midEntry = true;
            var topEntry = false;
            var botExit = false;
            var midExit = false;
            var topExit = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "==========222222"//
                    , "==========111111"//
                    , "==========111111"//
                    , "====222222111111"//
                    , "====111111111111"//E
                    , "====111111111111"//E
                    , "2222111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionTopMid()
        {
            var botEntry = false;
            var midEntry = false;
            var topEntry = true;
            var botExit = false;
            var midExit = true;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "2222============"//
                    , "1111============"//
                    , "1111============"//
                    , "1111222222======"//
                    , "1111111111======"//E
                    , "1111111111======"//E
                    , "1111111111222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionBotTop()
        {
            var botEntry = true;
            var midEntry = false;
            var topEntry = false;
            var botExit = false;
            var midExit = false;
            var topExit = true;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "===============2"//
                    , "===============1"//
                    , "===============1"//
                    , "============2221"//
                    , "============1111"//E
                    , "============1111"//E
                    , "========22221111"//
                    , "========11111111"//
                    , "========11111111"//
                    , "====222211111111"//
                    , "====111111111111"//E
                    , "====111111111111"//E
                    , "2222111111111111")
            };
        }

        private static List<MapModuleInfo> TransitionTopBot()
        {
            var botEntry = false;
            var midEntry = false;
            var topEntry = true;
            var botExit = true;
            var midExit = false;
            var topExit = false;

            return new List<MapModuleInfo> {
                new MapModuleInfo(
                     topEntry
                    , midEntry
                    , botEntry
                    , topExit
                    , midExit
                    , botExit
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "2==============="//
                    , "1==============="//
                    , "1==============="//
                    , "1222============"//
                    , "1111============"//E
                    , "1111============"//E
                    , "11112222========"//
                    , "11111111========"//
                    , "11111111========"//
                    , "1111111122222==="//
                    , "1111111111111==="//E
                    , "1111111111111==="//E
                    , "1111111111111222")                
            };
        }
    }

}
