//namespace GameCore
//{
//    public class InputCheckerAggregation : InputChecker
//    {
//        private readonly InputChecker[] InputCheckers;

//        public InputCheckerAggregation(params InputChecker[] InputCheckers)
//        {
//            this.InputCheckers = InputCheckers;
//        }

//        public bool Action
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Action;
//                }

//                return result;
//            }
//        }

//        public bool Down
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Down;
//                }

//                return result;
//            }
//        }

//        public bool Jump
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Jump;
//                }

//                return result;
//            }
//        }

//        public bool Left
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Left;
//                }

//                return result;
//            }
//        }

//        public bool Right
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Right;
//                }

//                return result;
//            }
//        }

//        public bool Up
//        {
//            get
//            {
//                var result = false;

//                foreach (var item in InputCheckers)
//                {
//                    result = result || item.Up;
//                }

//                return result;
//            }
//        }

//        public void Update()
//        {
//            foreach (var item in InputCheckers)
//            {
//                item.Update();
//            }
//        }
//    }
//}