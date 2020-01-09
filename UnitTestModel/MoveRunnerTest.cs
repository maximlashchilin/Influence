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

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void MoveToFreeCellTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = testPlayers[0];

      // Act
      moveRunner.Move(moveRunner.Cells[0, 0], moveRunner.Cells[0, 1], currentPlayer);

      // Assert
      Assert.AreEqual(moveRunner.Cells[0, 1].Owner, currentPlayer);
    }

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void MoveToOccupiedCellTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = testPlayers[0];

      // Act
      moveRunner.Move(moveRunner.Cells[0, 0], moveRunner.Cells[0, 1], currentPlayer);

      // Assert
      Assert.AreEqual(moveRunner.Cells[0, 1].Owner, currentPlayer);
    }

    /// <summary>
    /// Тестирует передачу в IsMove
    /// отрицательных координат ячеек
    /// </summary>
    [TestMethod]
    public void IsMoveNegativeSourceCoordsTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(-1, 0, moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J);

      // Assert
      Assert.IsFalse(result);
    }

    /// <summary>
    /// Тестирует передачу в IsMove
    /// значений координат ячеек больше
    /// размера карты
    /// </summary>
    [TestMethod]
    public void IsMoveSourceCoordsMoreSizeTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(VERTICAL_SIZE + 1, 0, moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J);

      // Assert
      Assert.IsFalse(result);
    }

    /// <summary>
    /// Тестирует передачу в IsMove
    /// координат ячейки назначения,
    /// которая является Null
    /// </summary>
    [TestMethod]
    public void IsMoveDestinationCellNullTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[0, 3].I, moveRunner.Cells[0, 3].J, 1, 3);

      // Assert
      Assert.IsFalse(result);
    }

    /// <summary>
    /// Тестирует переход из правой ячейки
    /// в левую
    /// </summary>
    [TestMethod]
    public void IsMoveFromRightToLeftTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J, moveRunner.Cells[0, 0].I, moveRunner.Cells[0, 0].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует переход из левой ячейки
    /// в правую
    /// </summary>
    [TestMethod]
    public void IsMoveFromLeftToRightTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[0, 0].I, moveRunner.Cells[0, 0].J, moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует переход из верхней ячейки
    /// в нижнюю
    /// </summary>
    [TestMethod]
    public void IsMoveFromTopToBottomTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[1, 1].I, moveRunner.Cells[1, 1].J, moveRunner.Cells[2, 1].I, moveRunner.Cells[2, 1].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует переход из нижней ячейки
    /// в верхнюю
    /// </summary>
    [TestMethod]
    public void IsMoveFromBottomToTopTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[1, 1].I, moveRunner.Cells[1, 1].J, moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует возможный переход из ряда с четным
    /// индексом по диагонали
    /// </summary>
    [TestMethod]
    public void IsMoveFromTopToBottomDiagonallyFromEvenTrueTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[0, 1].I, moveRunner.Cells[0, 1].J, moveRunner.Cells[1, 0].I, moveRunner.Cells[1, 0].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует невозможный переход из ряда с четным
    /// индексом по диагонали
    /// </summary>
    [TestMethod]
    public void IsMoveFromTopToBottomDiagonallyFromEvenFalseTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[0, 0].I, moveRunner.Cells[0, 0].J, moveRunner.Cells[1, 1].I, moveRunner.Cells[1, 1].J);

      // Assert
      Assert.IsFalse(result);
    }

    /// <summary>
    /// Тестирует возможный переход из ряда с нечетным
    /// индексом по диагонали
    /// </summary>
    [TestMethod]
    public void IsMoveFromTopToBottomDiagonallyFromOddTrueTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[3, 0].I, moveRunner.Cells[3, 0].J, moveRunner.Cells[4, 1].I, moveRunner.Cells[4, 1].J);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует возможный переход из ряда с нечетным
    /// индексом по диагонали
    /// </summary>
    [TestMethod]
    public void IsMoveFromTopToBottomDiagonallyFromOddFalseTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));

      // Act
      bool result = moveRunner.IsMove(moveRunner.Cells[3, 1].I, moveRunner.Cells[3, 1].J, moveRunner.Cells[4, 0].I, moveRunner.Cells[4, 0].J);

      // Assert
      Assert.IsFalse(result);
    }

    /// <summary>
    /// Тестирует метод IsCellOccupied
    /// при передаче игрока со значением <see langword="null"/>
    /// </summary>
    [TestMethod]
    public void IsCellOccupiedNullPlayerTest()
    {
      // Arrange
      List<Player> testPlayers = ReadyPlayers();
      MoveRunner moveRunner = new MoveRunner(new MapBuilder().BuildMap(VERTICAL_SIZE, HORIZONTAL_SIZE, testPlayers));
      Player currentPlayer = null;

      // Act
      bool result = moveRunner.IsCellOccupied(moveRunner.Cells[0, 3], currentPlayer);

      // Assert
      Assert.IsTrue(result);
    }

    /// <summary>
    /// Тестирует метод IsCellOccupied
    /// при передаче в него ячейки со значением <see langword="null"/>
    /// </summary>
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

    /// <summary>
    /// Тестирует метод IsCellOccupied
    /// при передаче в него ячейки,
    /// которой владеет другой игрок
    /// </summary>
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

    /// <summary>
    /// Тестирует метод IsCellOccupied
    /// при передаче в него ячейки,
    /// которой владеет текущий игрок
    /// </summary>
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

    /// <summary>
    /// Подготавливает список игроков
    /// </summary>
    /// <returns>Список игроков</returns>
    private List<Player> ReadyPlayers()
    {
      List<Player> testPlayers = new List<Player>
      {
        new Player("Player1", ItemColors.Red),
        new Player("Player2", ItemColors.Green)
      };

      return testPlayers;
    }
  }
}
