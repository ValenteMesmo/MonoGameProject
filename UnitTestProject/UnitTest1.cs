using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MonoGameProject;
using GameCore;
using NSubstitute;

namespace UnitTestProject
{
    [TestClass]
    public class AttackTransitionTests
    {
        [TestMethod]
        public void PreventStandWhileCrouchAttackingLeft()
        {
            var inputs = Substitute.For<InputChecker>();
            var sut = new Humanoid(new GameInputs(inputs), new Camera2d());
            sut.groundChecker.CollidingWith.Add(new GroundCollider());

            inputs.Down.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(LegState.Crouching, sut.LegState);
            Assert.AreEqual(false, sut.FacingRight);

            inputs.Action.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(LegState.Crouching, sut.LegState);
            Assert.AreEqual(false, sut.FacingRight);
            Assert.AreEqual(TorsoState.AttackCrouching, sut.TorsoState);

            inputs.Action.Returns(false);
            inputs.Down.Returns(false);
            foreach (var item in sut.Updates)
            {
                item();
            }

            Assert.AreEqual(LegState.Crouching, sut.LegState);
            Assert.AreEqual(TorsoState.AttackCrouching, sut.TorsoState);
            Assert.AreEqual(false, sut.FacingRight);
        }

        [TestMethod]
        public void PreventCrouchAttackingLeft()
        {
            var inputs = Substitute.For<InputChecker>();
            var sut = new Humanoid(new GameInputs(inputs), new Camera2d());
            sut.groundChecker.CollidingWith.Add(new GroundCollider());

            sut.Updates.ForEach(f => f());
            Assert.AreEqual(LegState.Standing, sut.LegState);
            Assert.AreEqual(false, sut.FacingRight);

            inputs.Action.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(LegState.Standing, sut.LegState);
            Assert.AreEqual(TorsoState.Attack, sut.TorsoState);
            Assert.AreEqual(false, sut.FacingRight);

            inputs.Action.Returns(false);
            inputs.Down.Returns(true);
            foreach (var item in sut.Updates)
            {
                item();
            }

            Assert.AreEqual(LegState.Standing, sut.LegState);
            Assert.AreEqual(TorsoState.Attack, sut.TorsoState);
            Assert.AreEqual(false, sut.FacingRight);
        }

        [TestMethod]
        public void PreventDirectionCHangeWhileCrouchAttackingLeft()
        {
            var inputs = Substitute.For<InputChecker>();
            var sut = new Humanoid(new GameInputs(inputs), new Camera2d());
            sut.groundChecker.CollidingWith.Add(new GroundCollider());

            inputs.Down.Returns(true);
            inputs.Right.Returns(false);
            inputs.Left.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(false, sut.FacingRight);

            inputs.Action.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(sut.TorsoState, TorsoState.AttackCrouching);
            Assert.AreEqual(false, sut.FacingRight);

            inputs.Action.Returns(false);
            inputs.Right.Returns(true);
            foreach (var item in sut.Updates)
            {
                item();
            }

            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(sut.TorsoState, TorsoState.AttackCrouching);
            Assert.AreEqual(false, sut.FacingRight);
        }

        [TestMethod]
        public void PreventDirectionCHangeWhileCrouchAttackingRight()
        {
            var inputs = Substitute.For<InputChecker>();
            var sut = new Humanoid(new GameInputs(inputs), new Camera2d());
            sut.groundChecker.CollidingWith.Add(new GroundCollider());

            inputs.Down.Returns(true);
            inputs.Right.Returns(true);
            inputs.Left.Returns(false);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(sut.FacingRight, true);

            inputs.Action.Returns(true);
            sut.Updates.ForEach(f => f());
            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(sut.TorsoState, TorsoState.AttackCrouching);
            Assert.AreEqual(sut.FacingRight, true);

            inputs.Action.Returns(false);
            inputs.Right.Returns(false);
            inputs.Left.Returns(true);
            foreach (var item in sut.Updates)
            {
                item();
            }

            Assert.AreEqual(sut.LegState, LegState.Crouching);
            Assert.AreEqual(sut.TorsoState, TorsoState.AttackCrouching);
            Assert.AreEqual(sut.FacingRight, true);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private TilesFromStrings sut = new TilesFromStrings();

        [TestMethod]
        public void TestMethod2()
        {
            var actual = sut.Create("111").First();
            Assert.AreEqual('1', actual.Type);
            Assert.AreEqual(1, actual.X);
            Assert.AreEqual(1, actual.Y);
            Assert.AreEqual(3, actual.Width);
            Assert.AreEqual(1, actual.Height);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var actual = sut.Create("0001111111111111").ToArray();
            Assert.AreEqual('0', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(3, actual[0].Width);
            Assert.AreEqual(1, actual[0].Height);

            Assert.AreEqual('1', actual[1].Type);
            Assert.AreEqual(4, actual[1].X);
            Assert.AreEqual(1, actual[1].Y);
            Assert.AreEqual(13, actual[1].Width);
            Assert.AreEqual(1, actual[1].Height);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var actual = sut.Create(
                  "10"
                , "10").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(1, actual[0].Width);
            Assert.AreEqual(2, actual[0].Height);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var actual = sut.Create(
                  "110"
                , "110").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(2, actual[0].Width);
            Assert.AreEqual(2, actual[0].Height);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var actual = sut.Create(
                  "100"
                , "111").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(1, actual[0].Width);
            Assert.AreEqual(1, actual[0].Height);

            Assert.AreEqual('0', actual[1].Type);
            Assert.AreEqual(2, actual[1].X);
            Assert.AreEqual(1, actual[1].Y);
            Assert.AreEqual(2, actual[1].Width);
            Assert.AreEqual(1, actual[1].Height);

            Assert.AreEqual('1', actual[2].Type);
            Assert.AreEqual(1, actual[2].X);
            Assert.AreEqual(2, actual[2].Y);
            Assert.AreEqual(3, actual[2].Width);
            Assert.AreEqual(1, actual[2].Height);
        }


        [TestMethod]
        public void TestMethod7()
        {
            var actual = sut.Create(
                  "111"
                , "101").ToArray();

            Assert.AreEqual(4, actual.Length);

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(3, actual[0].Width);
            Assert.AreEqual(1, actual[0].Height);

            Assert.AreEqual('1', actual[1].Type);
            Assert.AreEqual(1, actual[1].X);
            Assert.AreEqual(2, actual[1].Y);
            Assert.AreEqual(1, actual[1].Width);
            Assert.AreEqual(1, actual[1].Height);

            Assert.AreEqual('0', actual[2].Type);
            Assert.AreEqual(2, actual[2].X);
            Assert.AreEqual(2, actual[2].Y);
            Assert.AreEqual(1, actual[2].Width);
            Assert.AreEqual(1, actual[2].Height);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var actual = sut.Create(
                  "000"
                , "111"
                , "111").ToArray();

            Assert.AreEqual(2, actual.Length);
        }

        [TestMethod]
        public void TestMethod9()
        {
            var actual = sut.Create(
                  "111"
                , "110"
                , "110").ToArray();

            Assert.AreEqual(3, actual.Length);
        }

        [TestMethod]
        public void TestMethod10()
        {
            var actual = sut.Create(
                    "11101"
                  , "10001"
                  , "10111").ToArray();

            Assert.AreEqual(7, actual.Length);

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(3, actual[0].Width);
            Assert.AreEqual(1, actual[0].Height);

            Assert.AreEqual('0', actual[1].Type);
            Assert.AreEqual(1, actual[1].Width);
            Assert.AreEqual(1, actual[1].Height);

            Assert.AreEqual('1', actual[2].Type);
            Assert.AreEqual(1, actual[2].Width);
            Assert.AreEqual(2, actual[2].Height);
        }

    }
}