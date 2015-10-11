using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth2Tests
{
    using Labyrinth.Core.PlayField;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Core.Helpers.Contracts;
    using Labyrinth.Core.Helpers;
    [TestClass]
  public  class PlayFieldTests
    {
        [TestMethod]
        public void TestPlayFieldWithCorrectData()
        {
            var position = new Position(0, 2);
            var  generator = new StandardPlayFieldGenerator(position,3, 3);
            PlayField field = new PlayField(generator,position,4,4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayFieldWithIncorrectData()
        {
            var position = new Position(55, 55);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            PlayField field = new PlayField(generator, position, 4, 4);
        }
		
		  [TestMethod]
        public void CheskPlayFieldRowsGetter()
        {
            var position = new Position(0, 2);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            int row=4;
            int col = 5;
            PlayField field = new PlayField(generator, position, row, col);
            Assert.AreEqual(row,field.NumberOfRows);

        }

         [TestMethod]
        public void CheskPlayFieldCollsGetter()
        {
            var position = new Position(0, 2);
            var generator = new StandardPlayFieldGenerator(position, 3, 3);
            int row = 4;
            int col = 5;
            PlayField field = new PlayField(generator, position, row, col);
            Assert.AreEqual(col, field.NumberOfCols);

        }


         

    }
}
