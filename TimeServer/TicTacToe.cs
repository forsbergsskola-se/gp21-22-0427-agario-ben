using System.Net.Sockets;
using Microsoft.VisualBasic;

namespace TimeServer; 

public class TicTacToe {
	public enum CellState {
		Empty,
		X,
		O
	}

	public CellState[,] grid = new CellState[3, 3];

	public TcpClient x;
	public TcpClient o;

	private bool AnyPlayerWon => GetWinner() != CellState.Empty;
	private CellState activePlayer = CellState.X;
	
	CellState GetWinner() {
		return CellState.Empty;
	}
	
	public void Start() {
		while (!AnyPlayerWon) {
			if (activePlayer == CellState.X) {
				// Print info to Player X
				var streamWriter = new StreamWriter(x.GetStream());
				streamWriter.WriteLine("It's your turn! Pick a cell!");
				streamWriter.Write(PrintGrid());
				streamWriter.Flush();
				
				// Wait for Player X to pick
				var streamReader = new StreamReader(x.GetStream());
				Console.WriteLine($"Waiting for Player {activePlayer}...");
				var pick = streamReader.ReadLine();
				Console.WriteLine($"Player {activePlayer} picked: {pick}");
				
				// Print pick to Player O
				var otherWriter = new StreamWriter(o.GetStream());
				otherWriter.WriteLine($"Player {activePlayer} picked: {pick}");
				otherWriter.Flush();
			}
		}
	}
	IEnumerable<IEnumerable<CellState>> GetRows() {
		for (int y = 0; y < grid.GetLength(1); y++) {
			yield return GetRow(y);
		}
	}

	IEnumerable<CellState> GetRow(int y) {
		for (int x = 0; x < grid.GetLength(2); x++) {
			yield return grid[x, y];
		}
	}

	string PrintCell(CellState cellState) {
		
		return cellState switch {
			CellState.Empty => " ",
			_ => cellState.ToString()
		};
	}

	string PrintRow(IEnumerable<CellState> row) {
		return string.Join("|", row);
	}

	string PrintGrid() {
		return string.Join("\n------\n", GetRows().Select(PrintRow));
	}
}
