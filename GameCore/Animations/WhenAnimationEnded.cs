//using System;

//namespace GameCore
//{
//    public class WhenAnimationEnded : AnimationTransition
//    {
//        public IHandleAnimation[] Sources { get; }
//        public IHandleAnimation Target { get; }
//        public Func<bool> Condition { get; }
//        public Action AfterTransition { get; }

//        public WhenAnimationEnded(IHandleAnimation Source, IHandleAnimation Target, Func<bool> Condition, Action AfterTransition = null)
//        {
//            this.Sources = new[] { Source };
//            this.Target = Target;
//            this.Condition = () => Condition() && Source.Ended;

//            if (AfterTransition != null)
//                this.AfterTransition = AfterTransition;
//            else
//                this.AfterTransition = () => { };
//        }
//    }
//}
