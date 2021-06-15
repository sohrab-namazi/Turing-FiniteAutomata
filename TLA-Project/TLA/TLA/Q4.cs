using System;
using System.Collections.Generic;
using System.Text;

namespace TLA
{
    public class Q4
    {
        //public static void Main(String[] args)
        //{
        //    L4 l4 = new L4();
        //    Console.WriteLine(l4.CheckString("abbbbaaa"));
        //}


    }

    public class L4 : Q
    {
        public PDA pda;
        public List<char> Alphabet;

        public L4()
        {
            Alphabet = new List<char>();
            Alphabet.Add('a');
            Alphabet.Add('b');
            int StateCount = 5;
            pda = new PDA(StateCount);
            State q0 = pda.States[0];
            State q1 = pda.States[1];
            State q2 = pda.States[2];
            State q3 = pda.States[3];
            State q4 = pda.States[4];
            q0.AddTransition('a', '-', 'a', q1);
            q1.AddTransition('a', '-', 'a', q1);
            q1.AddTransition('b', 'a', '-', q2);
            q2.AddTransition('b', 'a', '-', q2);
            q2.AddTransition('b', '-', 'b', q2);
            q2.AddTransition('a', 'b', '-', q3);
            q3.AddTransition('a', 'b', '-', q3);
            q3.AddTransition('-', '$', '$', q4);
            pda.SetFinalState(4);
        }

        public string CheckString(string w)
        {
            string Result = "";
            State CurrentState = pda.States[0];

            foreach (char c in w)
            {
                Result += "Reading : " + c + "\n";
                string StackContents = "\n";
                foreach (char l in pda.Stack) StackContents += l + "\n";
                Result += "Stack Contents : " + StackContents;
                Result += "\n";
                List<Edge> edges = CurrentState.HasTransition(c);
                if (edges.Count == 0) return "Rejected";
                bool HasTransition = false;
                string candidate = "";
                foreach (Edge edge in edges)
                {
                    candidate += "Popping : " + edge.Pop + "\n";
                    candidate += "Pushing : " + edge.Push + "\n";
                    bool IsPossible = pda.EditStack(edge.Pop, edge.Push);
                    if (!IsPossible)
                    {
                        candidate = "";
                        continue;
                    }
                    else
                    {
                        HasTransition = true;
                    }
                    CurrentState = edge.OutState;
                    candidate += "\n\n";
                }
                if (!HasTransition) return "Rejected";
                Result += candidate;
            }

            List<Edge> Edges = CurrentState.HasTransition('-');
            if (Edges.Count == 0) return "Rejeceted";
            Edge EdgeToFinal = Edges[0];
            if (EdgeToFinal == null) return "Rejected";
            bool IsPossibleLastMovement = pda.EditStack(EdgeToFinal.Pop, EdgeToFinal.Push);
            if (!IsPossibleLastMovement) return "Rejected";
            CurrentState = EdgeToFinal.OutState;

            Result += "Reading : -\n";
            string StackContentsLast = "\n";
            foreach (char l in pda.Stack) StackContentsLast += l + "\n";
            Result += "Stack Contents :" + StackContentsLast;
            Result += "\n";
            Result += "Popping : " + EdgeToFinal.Pop + "\n";
            Result += "Pushing : " + EdgeToFinal.Push + "\n";

            Result += "\nString Finished\n";
            Result += "Stack Contents :\n" + '$';


            if (CurrentState.IsFinal == true)
            {
                return "Accepted\n\n" + Result;
            }

            return "Rejected";
        }


        public class PDA
        {
            public long StateCount;
            public List<char> StackAlphabet;
            public List<State> States;
            public Stack<char> Stack;
            public State FinalState;

            public PDA(int n)
            {
                StateCount = n;
                StackAlphabet = new List<char>();
                StackAlphabet.Add('a');
                StackAlphabet.Add('b');
                States = new List<State>();
                for (int i = 0; i < StateCount; i++)
                {
                    States.Add(new State(i));
                }
                Stack = new Stack<char>();
                Stack.Push('$');
            }

            public void SetFinalState(int n)
            {
                States[n].IsFinal = true;
                FinalState = States[n];
            }

            internal bool EditStack(char pop, char push)
            {
                if (pop != '-')
                {
                    char Popped = Stack.Pop();
                    if (Popped != pop)
                    {
                        Stack.Push(Popped);
                        return false;
                    }
                }

                if (push != '-')
                {
                    Stack.Push(push);
                }

                return true;
            }
        }

        public class Edge
        {
            public char Input;
            public char Pop;
            public char Push;
            public State OutState;

            public Edge(char Input, char Pop, char Push, State OutState)
            {
                this.Input = Input;
                this.Pop = Pop;
                this.Push = Push;
                this.OutState = OutState;
            }
        }

        public class State
        {
            public string Number = "q";
            public List<Edge> OutTransitions;
            public bool IsFinal = false;

            public State(int n)
            {
                this.Number += n;
                OutTransitions = new List<Edge>();
            }

            public void AddTransition(char Input, char Pop, char Push, State OutState)
            {
                OutTransitions.Add(new Edge(Input, Pop, Push, OutState));
            }

            public List<Edge> HasTransition(char a)
            {
                List<Edge> Edges = new List<Edge>();

                foreach (Edge edge in OutTransitions)
                {
                    if (edge.Input.Equals(a))
                    {
                        Edges.Add(edge);
                    }
                }
                return Edges;
            }
        }

    }

}
