using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestModel
{
  [TestClass]
  public class MoveRunnerTest
  {
    /// <summary>
    /// Число рядов
    /// </summary>
    private const int VERTICAL_SIZE = 6;

    /// <summary>
    /// Число ячеек в строке
    /// </summary>
    private const int HORIZONTAL_SIZE = 4;

    [TestMethod]
    public void IsCellOccupiedNullPlayerTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = null;

      // Act
      bool result = moveRunner.IsCellOccupied(moveRunner.Cells[0, 2], currentPlayer);

      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsCellOccupiedNullCellTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = testPlayers[0];

      // Act and assert
      Assert.ThrowsException<NullReferenceException>(() => moveRunner.IsCellOccupied(null, currentPlayer));
    }

    [TestMethod]
    public void IsCellOccupiedTrueTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = testPlayers[0];

      // Act
      bool result = moveRunner.IsCellOccupied(moveRunner.Cells[0, 2], currentPlayer);

      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsCellOccupiedFalseTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = testPlayers[0];

      // Act
      bool result = moveRunner.IsCellOccupied(moveRunner.Cells[0, 0], currentPlayer);

      // Assert
      Assert.IsFalse(result);
    }

    private List<Player> ReadyPlayers()
    {
      List<Player> testPlayers = new List<Player>();
      testPlayers.Add(new Player("Player1", ItemColor.Red));
      testPlayers.Add(new Player("Player2", ItemColor.Green));

      return testPlayers;
    }
  }
}
