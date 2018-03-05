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
                    , "0000000000000000"//E
                    , "i000000jj000000i"//E
                    , "2uuuuuuuuuuuuuu2")

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
                    , "2uuuuu22uuu2uuu2"//
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
                    , "111111UUUUU11111"//
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
                    , "0000000000000002"//
                    , "0000000022000001"//
                    , "0000000011000001"//
                    , "0022000011000001"//
                    , "00110000110000a1"//E
                    , "0011000011000001"//E
                    , "2211uuuu11uuuu11")
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
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000000"//E
                    , "0000000000000002"//
                    , "0000000022000001"//
                    , "0000000011000001"//
                    , "0022000011000001"//
                    , "0011000011000001"//E
                    , "0011000011000001"//E
                    , "2211uuuu11uuuuu1")
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
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//
                    , "0000000000000000"//E
                    , "0000000000000i00"//E
                    , "0000000000000002"//
                    , "0000000000000001"//
                    , "0000000000000001"//
                    , "0000000000000001"//
                    , "0000000000000001"//E
                    , "0000000000000kk1"//E
                    , "2222222222222221")
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
                    , "1111222000000000"//
                    , "1111111000000000"//
                    , "1111111222200000"//E
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
                    , "1200000000000000"//
                    , "1100000000000000"//
                    , "1120000000000000"//E
                    , "1110000000000000"//E
                    , "1112000000000000"//
                    , "1111000000000000"//
                    , "1111200000000000"//
                    , "1111100000000000"//
                    , "1111120000000000"//E
                    , "1111110000000000"//E
                    , "1111112222222222")
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
                    , "10000000000000i0"//E
                    , "10000jjjj00002kk"//
                    , "1000000000000100"//
                    , "1000000000000100"//
                    , "1000000000000100"//
                    , "10a0000000000100"//E
                    , "100uuuuuuuuuu100"//E
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
                    , "=00==00==00==00="//E
                    , "================"//E
                    , "2222222222222222")
                    ,new MapModuleInfo(
                     top
                    , mid
                    , bot
                    , top
                    , mid
                    , bot
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//E
                    , "================"//E
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//
                    , "================"//E
                    , "================"//E
                    , "2222222222222222")

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
                    , "2====22====2===2"//
                    , "1UUUU11UUUU1UUU1"//
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
                    , "111111UUUUU11111"//
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
                    , "1110000000000111"//
                    , "1100000000000011"//
                    , "1000000000000001"//
                    , "1000000000000001"//E
                    , "1000000000000001"//E
                    , "1000000000000001"//
                    , "1000000000000001"//
                    , "1000000000000001"//
                    , "1000000000000001"//
                    , "1000000000000001"//E
                    , "1000000000000001"//E
                    , "1000000000000001")
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
                    , "=00==00==00==00="//E
                    , "=00==00==00====="//E
                    , "=00==00==00===22"//
                    , "=00==00==00===11"//
                    , "=00==00==00=2211"//
                    , "=00==00=====1111"//
                    , "=00==00===221111"//E
                    , "==========111111"//E
                    , "2222222222111111")
                    ,new MapModuleInfo(
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
                    , "=00==00==00==I=="//E
                    , "=00==00==00====2"//
                    , "=00==00==00====1"//
                    , "=00==00==00====1"//
                    , "=00==00==00====1"//
                    , "=00==00==00====1"//E
                    , "=============KK1"//E
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
                    , "1000000000000001"//
                    , "1000000000000001"//E
                    , "1000000000000001"//E
                    , "1000000000000001"//
                    , "1100000000000011"//
                    , "1110000000000111"//
                    , "1111111111111111"//
                    , "================"//E
                    , "================"//E
                    , "2222============"//
                    , "1111============"//
                    , "1111============"//
                    , "11112222222====="//
                    , "11111111111====="//E
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
                    , "==========100111"//
                    , "==========100011"//
                    , "====222222100001"//
                    , "====100000000001"//E
                    , "====100000000001"//E
                    , "2222100000000001"//
                    , "1110000000000001"//
                    , "1100000000000001"//
                    , "1000000000000001"//
                    , "1000000000000001"//E
                    , "1000000000000001"//E
                    , "1000000000000001")
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
                    , "1100000000000011"//
                    , "1000000000000001"//
                    , "1000000000000001"//
                    , "1000000000000001"//E
                    , "1000000000000001"//E
                    , "1000000000000001")
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
                    , "111111111111===="//E
                    , "111111111111==I="//E
                    , "111111111111KKK2"//
                    , "111111111111===1"//
                    , "111111111111===1"//
                    , "111111111111===1"//
                    , "111111111111===1"//E
                    , "111111111111===1"//E
                    , "111111111111===1"//
                    , "111111111111===1"//
                    , "11111111=======1"//
                    , "1111===========1"//
                    , "===============1"//E
                    , "=========111===1"//E
                    , "222211111111UUU1")
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
                    , "1===I==========="//
                    , "1222KKK========="//
                    , "1111============"//E
                    , "1111============"//E
                    , "1111============"//
                    , "1111============"//
                    , "1111============"//
                    , "1111============"//
                    , "1111============"//E
                    , "1111============"//E
                    , "1111111111111222")
            };
        }
    }

}
