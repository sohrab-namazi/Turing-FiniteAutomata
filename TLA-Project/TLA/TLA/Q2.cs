using System;
using System.Collections.Generic;
using System.Text;

namespace TLA
{
    public class Q2
    {
        //public static void Main(string[] args)
        //{
        //    L2 l2 = new L2();
        //    string res = l2.CheckString("cabacbabaaabb");
        //    Console.WriteLine(res);
        //}
    }

    public class L2 : Q
    {
        public FA FA;
        public List<char> Alphabets;

        public L2()
        {
            int StateCount = 3;
            FA = new FA(StateCount);
            Alphabets = new List<char>();
            Alphabets.Add('a');
            Alphabets.Add('b');
            Alphabets.Add('c');
            State q0 = FA.States[0];
            State q1 = FA.States[1];
            State q2 = FA.States[2];
            q0.AddTransition('c', q0);
            q1.AddTransition('c', q1);
            q2.AddTransition('c', q2);
            q0.AddTransition('a', q1);
            q0.AddTransition('b', q2);
            q1.AddTransition('a', q2);
            q1.AddTransition('b', q0);
            q2.AddTransition('a', q0);
            q2.AddTransition('b', q1);
            FA.SetFinalState(1);
        }

        public string CheckString(string w)
        {
            State CurrentState = FA.States[0];
            string Output = "\n";

            foreach (char c in w)
            {
                Edge edge = CurrentState.HasTransition(c);
                if (edge != null)
                {
                    Output += "CurrentState : " + CurrentState.Number + "\nReading : " + edge.Character + "\n";
                    CurrentState = edge.OutState;
                }
                else
                {
                    Output = "Rejected";
                    return Output;
                }
                Output += "\n";
            }

            Output += "Current state : " + CurrentState.Number + "\nString Finished";

            if (CurrentState.IsFinal)
            {
                Output = "Accepted\n" + Output;
                return Output;
            }
            Output = "Rejected";
            return Output;
        }
    }

    public class FA
    {
        public int StateCount;
        public List<State> States;
        public State FinalState;

        public FA(int n)
        {
            StateCount = n;
            States = new List<State>();
            for (int i = 0; i < StateCount; i++) States.Add(new State(i));
        }

        public void SetFinalState(int n)
        {
            States[n].IsFinal = true;
            FinalState = States[n];
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

        public void AddTransition(char a, State state)
        {
            OutTransitions.Add(new Edge(a, state));
        }

        public Edge HasTransition(char a)
        {
            foreach (Edge edge in OutTransitions)
            {
                if (edge.Character.Equals(a))
                {
                    return edge;
                }
            }
            return null;
        }

    }

    public class Edge
    {
        public char Character;
        public State OutState;

        public Edge(char c, State state)
        {
            this.Character = c;
            this.OutState = state;
        }
    }
}
