using System;
using System.Collections.Generic;
using System.Text;

namespace TLA
{
    public class Q5
    {
    }

    public class L5 : Q
    {
        public TuringMachine turing;
        public List<char> Alphabet;
        public List<char> TapeAlphabet;

        public L5()
        {
            turing = new TuringMachine(13, 12);
            Alphabet = new List<char>() { 'a', 'b', 'c' };
            TapeAlphabet = new List<char>() { 'a', 'b', 'c', 'x', 'y', 'z', '$', '#', 'B' };

            #region Initialization

            turing.States[0].AddTransitions(turing.States[1], 'a', 'x', Movement.RIGHT);
            turing.States[0].AddTransitions(turing.States[1], 'b', 'y', Movement.RIGHT);
            turing.States[0].AddTransitions(turing.States[1], 'c', 'z', Movement.RIGHT);

            turing.States[1].AddTransitions(turing.States[1], 'a', 'a', Movement.RIGHT);
            turing.States[1].AddTransitions(turing.States[1], 'b', 'b', Movement.RIGHT);
            turing.States[1].AddTransitions(turing.States[1], 'c', 'c', Movement.RIGHT);

            turing.States[1].AddTransitions(turing.States[2], 'x', 'x', Movement.LEFT);
            turing.States[1].AddTransitions(turing.States[2], 'y', 'y', Movement.LEFT);
            turing.States[1].AddTransitions(turing.States[2], 'z', 'z', Movement.LEFT);
            turing.States[1].AddTransitions(turing.States[2], 'B', 'B', Movement.LEFT);

            turing.States[2].AddTransitions(turing.States[3], 'a', 'x', Movement.LEFT);
            turing.States[2].AddTransitions(turing.States[3], 'b', 'y', Movement.LEFT);
            turing.States[2].AddTransitions(turing.States[3], 'c', 'z', Movement.LEFT);

            turing.States[3].AddTransitions(turing.States[3], 'a', 'a', Movement.LEFT);
            turing.States[3].AddTransitions(turing.States[3], 'b', 'b', Movement.LEFT);
            turing.States[3].AddTransitions(turing.States[3], 'c', 'c', Movement.LEFT);

            turing.States[3].AddTransitions(turing.States[0], 'x', 'x', Movement.RIGHT);
            turing.States[3].AddTransitions(turing.States[0], 'y', 'y', Movement.RIGHT);
            turing.States[3].AddTransitions(turing.States[0], 'z', 'z', Movement.RIGHT);

            turing.States[0].AddTransitions(turing.States[4], 'x', 'x', Movement.LEFT);
            turing.States[0].AddTransitions(turing.States[4], 'y', 'y', Movement.LEFT);
            turing.States[0].AddTransitions(turing.States[4], 'z', 'z', Movement.LEFT);
            turing.States[0].AddTransitions(turing.States[4], 'B', 'B', Movement.LEFT);

            turing.States[4].AddTransitions(turing.States[4], 'x', 'a', Movement.LEFT);
            turing.States[4].AddTransitions(turing.States[4], 'y', 'b', Movement.LEFT);
            turing.States[4].AddTransitions(turing.States[4], 'z', 'c', Movement.LEFT);

            turing.States[4].AddTransitions(turing.States[5], 'B', 'B', Movement.RIGHT);

            turing.States[5].AddTransitions(turing.States[6], 'a', '#', Movement.RIGHT);

            turing.States[6].AddTransitions(turing.States[6], 'a', 'a', Movement.RIGHT);
            turing.States[6].AddTransitions(turing.States[6], 'b', 'b', Movement.RIGHT);
            turing.States[6].AddTransitions(turing.States[6], 'c', 'c', Movement.RIGHT);
            turing.States[6].AddTransitions(turing.States[6], '#', '#', Movement.RIGHT);
            turing.States[6].AddTransitions(turing.States[6], '$', '$', Movement.RIGHT);

            turing.States[6].AddTransitions(turing.States[7], 'x', '$', Movement.LEFT);

            turing.States[7].AddTransitions(turing.States[7], '$', '$', Movement.LEFT);
            turing.States[7].AddTransitions(turing.States[7], 'a', 'a', Movement.LEFT);
            turing.States[7].AddTransitions(turing.States[7], 'b', 'b', Movement.LEFT);
            turing.States[7].AddTransitions(turing.States[7], 'c', 'c', Movement.LEFT);

            turing.States[7].AddTransitions(turing.States[5], '#', '#', Movement.RIGHT);

            turing.States[5].AddTransitions(turing.States[8], 'b', '#', Movement.RIGHT);

            turing.States[8].AddTransitions(turing.States[8], 'a', 'a', Movement.RIGHT);
            turing.States[8].AddTransitions(turing.States[8], 'b', 'b', Movement.RIGHT);
            turing.States[8].AddTransitions(turing.States[8], 'c', 'c', Movement.RIGHT);
            turing.States[8].AddTransitions(turing.States[8], '#', '#', Movement.RIGHT);
            turing.States[8].AddTransitions(turing.States[8], '$', '$', Movement.RIGHT);

            turing.States[8].AddTransitions(turing.States[9], 'y', '$', Movement.LEFT);

            turing.States[9].AddTransitions(turing.States[9], '$', '$', Movement.LEFT);
            turing.States[9].AddTransitions(turing.States[9], 'a', 'a', Movement.LEFT);
            turing.States[9].AddTransitions(turing.States[9], 'b', 'b', Movement.LEFT);
            turing.States[9].AddTransitions(turing.States[9], 'c', 'c', Movement.LEFT);

            turing.States[9].AddTransitions(turing.States[5], '#', '#', Movement.RIGHT);

            turing.States[5].AddTransitions(turing.States[10], 'c', '#', Movement.RIGHT);

            turing.States[10].AddTransitions(turing.States[10], 'a', 'a', Movement.RIGHT);
            turing.States[10].AddTransitions(turing.States[10], 'b', 'b', Movement.RIGHT);
            turing.States[10].AddTransitions(turing.States[10], 'c', 'c', Movement.RIGHT);
            turing.States[10].AddTransitions(turing.States[10], '#', '#', Movement.RIGHT);
            turing.States[10].AddTransitions(turing.States[10], '$', '$', Movement.RIGHT);

            turing.States[10].AddTransitions(turing.States[11], 'z', '$', Movement.LEFT);

            turing.States[11].AddTransitions(turing.States[11], '$', '$', Movement.LEFT);
            turing.States[11].AddTransitions(turing.States[11], 'a', 'a', Movement.LEFT);
            turing.States[11].AddTransitions(turing.States[11], 'b', 'b', Movement.LEFT);
            turing.States[11].AddTransitions(turing.States[11], 'c', 'c', Movement.LEFT);

            turing.States[11].AddTransitions(turing.States[5], '#', '#', Movement.RIGHT);

            turing.States[5].AddTransitions(turing.States[12], '$', '$', Movement.RIGHT);
            turing.States[5].AddTransitions(turing.States[12], 'B', 'B', Movement.RIGHT);

            #endregion Initialization
        }

        public string CheckString(string w)
        {
            string Result = "";
            this.turing.Tape = new Tape(w);
            State CurrentState = turing.States[0];

            #region Parsing
            while (true)
            {
                Result += "Tape Contents :\n";
                foreach (char e in turing.Tape.array)
                {
                    Result += e + " ";
                }
                char c = turing.Tape.ReadTape();
                Result += "\nHead : " + turing.Tape.Head + " ( " + c + " ) " + "\n";
                Edge edge = CheckEdge(CurrentState, c);
                if (edge != null)
                {
                    Result += "Reading : " + edge.Read + "\n";
                    Result += "Writing : " + edge.Write + "\n";
                    Result += "State : " + edge.P.Index + "\n";
                    Result += "Moving : " + edge.Move.ToString() + "\n";
                }

                if (edge == null)
                {
                    if (CurrentState.IsFinal)
                    {
                        Result += "Halting in Final State : " + CurrentState.Index + "\n";
                        Console.WriteLine("Accpeted" + "\n");
                        return Result;
                    }
                    return "Rejected";
                }
                CurrentState = edge.Q;
                Result += "\n\n";
            }
            #endregion Parsing
        }

        public Edge CheckEdge(State state, char c)
        {
            foreach (Edge edge in state.OutTransitions)
            {
                if (edge.Read.Equals(c))
                {
                    turing.Tape.WriteTape(edge.Write);
                    turing.Tape.Head += (int)edge.Move;
                    return edge;
                }
            }
            return null;
        }

        public class TuringMachine
        {
            public int StateCount;
            public List<State> States;
            public State FinalState;
            public Tape Tape;

            public TuringMachine(int n, int f)
            {
                this.StateCount = n;
                States = new List<State>();
                for (int i = 0; i < StateCount; i++) States.Add(new State(i));
                SetFinalState(f);
            }

            public void SetFinalState(int i)
            {
                States[i].IsFinal = true;
                FinalState = States[i];
            }

        }

        public class State
        {
            public string Index;
            public List<Edge> OutTransitions;
            public bool IsFinal = false;

            public State(int i)
            {
                this.Index = "q" + i;
                OutTransitions = new List<Edge>();
            }

            public void AddTransitions(State q, char r, char w, Movement m)
            {
                OutTransitions.Add(new Edge(this, q, r, w, m));
            }
        }

        public class Edge
        {
            public char Read;
            public char Write;
            public Movement Move;
            public State P;
            public State Q;

            public Edge(State P, State Q, char r, char w, Movement m)
            {
                this.Read = r;
                this.Write = w;
                this.Move = m;
                this.P = P;
                this.Q = Q;
            }
        }

        public enum Movement
        {
            LEFT = -1, RIGHT = 1
        }

        public class Tape
        {
            public int Head;
            public char[] array;
            int Size;

            public Tape(string w)
            {
                Size = w.Length;
                array = new char[Size];
                Head = 0;

                for (int i = 0; i < Size; i++)
                {
                    array[i] = w[i];
                }
            }

            public char ReadTape()
            {
                try
                {
                    return array[Head];
                }
                catch (IndexOutOfRangeException e)
                {
                    return 'B';
                }
            }

            public void WriteTape(char c)
            {
                try
                {
                    array[Head] = c;
                }
                catch (IndexOutOfRangeException e)
                {

                }
            }

        }

    }

}
