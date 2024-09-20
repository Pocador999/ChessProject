# Chess Project

- This repository is my first programming project. I made this based on POO course. Most of the code is inspired by the classes, but some logics such as promoting, checkmate, and castle were made by me.
  
## Structure

```
ConsoleChess
├── board
│   ├── Board.cs            # (Contains logic for representing and manipulating the chess board)
│   ├── BoardException.cs   # (Defines exceptions related to board operations)
│   ├── Color.cs            # (Enumerates possible piece colors (Black, White))
│   └── Piece.cs            # (Abstract class representing chess pieces with common properties)
│       └── Position.cs     # (Defines a position data structure for board coordinates)
├── chess
│   └── Pieces              # (Contains every piece on the board with its movement logics)
│       ├── Bishop.cs             
│       ├── King.cs               
│       ├── Knight.cs             
│       ├── Pawn.cs               
│       ├── Queen.cs             
│       └── Rook.cs              
├── ChessMatch.cs           # (Manages the game flow, player turns, and check/checkmate conditions)
├── Program.cs              # (Entry point for the application, initializes and runs the chess game)
└── Screen.cs               # (Handles console output for board visualization and piece representation)
```

### Aditional Notes

- This project is finished and produces a fully functional chess game.
However, its pretty basic since its my first coding project.
I do pretend on improving it somewhere into the future, with an actual front-end and online playing support.
Thank you so much for the atention!
