using System;
using System.IO;
using System.Collections.Generic;

namespace CleanCodeExaminationV2
{
	class Program
	{
		public static void Main(string[] args)
		{
			IUserInterface ui = new ConsoleIO();
			IGame game = new MasterMind();
			IHighScore highScore = new TextFile(game.Name);
			
			GameController controller = new(ui, game, highScore);

			controller.Run();
		}
		
	}
}