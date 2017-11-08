//using GameCore;

//namespace MonoGameProject
//{
//    public class PatrolAiInputs : InputChecker
//    {
//        int time;

//        public PatrolAiInputs()
//        {
//            time = 0;
//            Right = true;
//        }

//        public bool Left { get; set; }

//        public bool Right { get; set; }

//        public bool Up { get; set; }

//        public bool Down { get; set; }

//        public bool Action { get; set; }

//        public bool Jump { get; set; }

//        public void Update()
//        {
//            time++;

//            if (time >= 100)
//            {
//                time = 0;
//                Jump = true;
//                Left = Right;
//                Right = !Left;
//            }
//            else if (time > 20)
//                Jump = false;
//        }
//    }
//}