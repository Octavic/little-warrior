using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Resource;
using Assets.Scripts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Resource.Tests
{
    [TestClass()]
    public class PizzaTests
    {
        private List<float> NormalTimes = new List<float>() { 1, 1, 1, 1, 1, 1, 1, 1 };

        [TestMethod()]
        public void ConstructorTest_ThrowWhenMismatch()
        {
            bool pizzaThrew = false;
            try
            {
                var pizza = new Pizza(new List<float>() { 1, 2, 3, 4, 5 });
            }
            catch
            {
                pizzaThrew = true;
            }

            Assert.IsTrue(pizzaThrew);
        }

        [TestMethod()]
        public void ApplyToppingTest()
        {
            var pizza = new Pizza(NormalTimes);
            pizza.ApplyTopping(Topping.GreenPepper);
            foreach (var slice in pizza.Slices)
            {
                Assert.IsTrue(slice.Toppings.Contains(Topping.GreenPepper));
            }

            pizza.ApplyTopping(Topping.Onion);
            foreach (var slice in pizza.Slices)
            {
                Assert.IsTrue(slice.Toppings.Contains(Topping.GreenPepper));
                Assert.IsTrue(slice.Toppings.Contains(Topping.Onion));
            }
        }

        [TestMethod()]
        public void BakeTest()
        {
            var pizza = new Pizza(new List<float> { 1, 2, 3, 4, 5, 6, 7, 8 });
            foreach (var slices in pizza.Slices)
            {
                Assert.IsFalse(slices.IsReady);
            }

            pizza.Bake(2);
            var expectedReady = new List<float>() { 0, 0, 1, 2, 3, 4, 5, 6 };
            this.ValidatePizza(pizza, expectedReady);
        }

        [TestMethod()]
        public void ConsumeSlicesTest_AllSuccess()
        {
            var pizza = new Pizza(new List<float> { 1, 1, 1, 1, 1, 1, 1, 1 });
            pizza.Bake(1);
            var result = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.A, Pattern.B });
            Assert.AreEqual(result.Count, 2);
            var expectedTimeLeft = new List<float>() { 1, 1, 0, 0, 0, 0, 0, 0 };
            this.ValidatePizza(pizza, expectedTimeLeft);
        }

        [TestMethod()]
        public void ConsumeSlicesTest_SomeFails()
        {
            var pizza = new Pizza(new List<float> { 1, 1, 1, 1, 1, 1, 1, 1 });
            pizza.Bake(1);
            var result1 = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.A, Pattern.B });
            Assert.AreEqual(result1.Count, 2);
            var expectedTimeLeft1 = new List<float>() { 1, 1, 0, 0, 0, 0, 0, 0 };
            this.ValidatePizza(pizza, expectedTimeLeft1);

            var result2 = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.B, Pattern.C });
            Assert.AreEqual(result2.Count, 1);
            var expectedTimeLeft2 = new List<float>() { 1, 1, 1, 0, 0, 0, 0, 0 };
            this.ValidatePizza(pizza, expectedTimeLeft2);
        }

        [TestMethod()]
        public void PizzaTest_EndToEnd()
        {
            // Make new pizza.
            var currentState = new List<float> { 1, 1, 1, 1, 1, 1, 1, 2 };
            var pizza = new Pizza(currentState);
            this.ValidatePizza(pizza, currentState);
            // Can't consume any slices
            var consumeResult = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.A });
            Assert.AreEqual(consumeResult.Count, 0);

            // Bake the pizza
            pizza.Bake(1);
            currentState = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 1 };
            this.ValidatePizza(pizza, currentState);
            // Can consume F,G, but not H
            consumeResult = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.F, Pattern.G, Pattern.H });
            Assert.AreEqual(consumeResult.Count, 2);
            currentState = new List<float>() { 0, 0, 0, 0, 0, 1, 1, 1 };
            this.ValidatePizza(pizza, currentState);

            // Add some toppings
            pizza.ApplyTopping(Topping.Pepperoni);
            var toppingState = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
            this.ValidatePizza(pizza, currentState, toppingState);
            // Consume the pizza
            consumeResult = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.A, Pattern.B });
            Assert.AreEqual(consumeResult.Count, 2);
            currentState = new List<float>() { 1, 1, 0, 0, 0, 1, 1, 1 };
            toppingState = new List<int>() { 0, 0, 1, 1, 1, 1, 1, 1 };
            this.ValidatePizza(pizza, currentState, toppingState);
            this.ValidateSlices(consumeResult, Topping.Pepperoni);

            // Bake some more
            pizza.Bake(1);
            currentState = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            this.ValidatePizza(pizza, currentState, toppingState);
            // Consume A again. Should be plain
            consumeResult = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.A});
            Assert.AreEqual(consumeResult.Count, 1);
            Assert.AreEqual(consumeResult[0].Toppings.Count, 0);
            // Consume H. Should have toppings (even though it's being baked when the topping was added)
            consumeResult = pizza.ConsumeSlices(new HashSet<Pattern>() { Pattern.H });
            currentState = new List<float>() { 1, 0, 0, 0, 0, 0, 0, 2 };
            toppingState = new List<int>() { 0, 0, 1, 1, 1, 1, 1, 0 };
            Assert.AreEqual(consumeResult.Count, 1);
            this.ValidatePizza(pizza, currentState, toppingState);
            this.ValidateSlices(consumeResult, Topping.Pepperoni);
        }
        private void ValidatePizza(Pizza pizza, List<float> expectedTimeLeft, List<int> expectedToppingCount = null)
        {
            for (int i = 0; i < Settings.SliceCount; i++)
            {
                var slice = pizza.Slices[i];
                Assert.AreEqual(slice.BakeTimeLeft, expectedTimeLeft[i]);

                if(expectedToppingCount != null)
                {
                    Assert.AreEqual(slice.Toppings.Count, expectedToppingCount[i]);
                }
            }
        }
        private void ValidateSlices(List<PizzaSlice> slices, Topping topping)
        {
            foreach(var slice in slices)
            {
                Assert.IsTrue(slice.Toppings.Contains(topping));
            }
        }
    }
}