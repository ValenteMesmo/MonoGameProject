//using System;
//using GameCore;

//namespace MonoGameProject
//{
//    internal class UpdatePlayerStatus
//    {
//        private Player player;

//        public UpdatePlayerStatus(Player player)
//        {
//            this.player = player;
//        }

//        internal void Update(Thing thing)
//        {
//            if (player.State == PlayerState.StandingLeft)
//            {
//                if (player.groundChecker.Colliding == false)
//                {
//                    if(player.g)
//                    player.State == PlayerState.FallingLeft;
//                }

//                if (player.State > 0 )
//                    player.State = PlayerState.WalkingRight;

//                return;
//            }
//            if (player.State == PlayerState.StandingRight)
//            {
//                return;
//            }
//            if (player.State == PlayerState.WalkingLeft)
//            {
//                return;
//            }
//            if (player.State == PlayerState.WalkingRight)
//            {
//                return;
//            }
//            if (player.State == PlayerState.FallingLeft)
//            {
//                return;
//            }
//            if (player.State == PlayerState.FallingRight)
//            {
//                return;
//            }
//            if (player.State == PlayerState.SlidingWallLeft)
//            {
//                return;
//            }
//            if (player.State == PlayerState.SlidingWallRight)
//            {
//                return;
//            }
//            //if (
//            //    player.groundChecker.Colliding
//            //    && player.HorizontalSpeed == 0
//            //    &&
//            //        (
//            //            player.State == PlayerState.WalkingLeft
//            //            || player.State == PlayerState.FallingLeft
//            //        )
//            //    )
//            //{
//            //    player.State = PlayerState.StandingLeft;
//            //}
//            //else if (
//            //    player.groundChecker.Colliding
//            //    && player.HorizontalSpeed == 0
//            //    &&
//            //        (
//            //            player.State == PlayerState.WalkingRight
//            //            || player.State == PlayerState.FallingRight
//            //        )
//            //    )
//            //{
//            //    player.State = PlayerState.StandingRight;
//            //}
//            //else if (
//            //  player.groundChecker.Colliding
//            //  && player.HorizontalSpeed > 0
//            //  )
//            //{
//            //    player.State = PlayerState.WalkingRight;
//            //}
//            //else if (
//            //   player.groundChecker.Colliding
//            //   && player.HorizontalSpeed < 0
//            //   )
//            //{
//            //    player.State = PlayerState.WalkingLeft;
//            //}
//            //else if (
//            //   player.groundChecker.Colliding == false
//            //   && player.HorizontalSpeed < 0
//            //   )
//            //{
//            //    player.State = PlayerState.FallingLeft;
//            //}
//            //else if (
//            //   player.groundChecker.Colliding == false
//            //   && player.HorizontalSpeed > 0
//            //   )
//            //{
//            //    player.State = PlayerState.FallingRight;
//            //}
//            //else if (
//            //   player.groundChecker.Colliding == false
//            //   && player.HorizontalSpeed > 0
//            //   )
//            //{
//            //    player.State = PlayerState.FallingRight;
//            //}
//        }
//    }
//}