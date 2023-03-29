using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace LZW
{
    public class Bor
    {
        private class BorNode
        {
            internal Dictionary<char, BorNode> nexts = new ();
            internal bool isTerminate { get; set; }
            internal int WordsWithSamePrefix { get; set; }
            public BorNode()
            {
                isTerminate = false;
                WordsWithSamePrefix = 0;
            }
        }
        private BorNode root;
        public int Size { get; private set; }
        private bool IsEmptyStringContained;

        public Bor()
        {
            IsEmptyStringContained = false;
            root = new BorNode();
            Size = 0;
        }
        /// <summary>
        /// Добавляет строку в дерево. возвращает true, если такой строки ещё не было, работает за O(|element|)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Add (string element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (element == "")
            {
                if (IsEmptyStringContained) return false;
                else
                {
                    IsEmptyStringContained = true;
                    Size++;
                    return true;
                }
            }
            if (Contains(element))
            {
                return false;
            }
            var CurrentNode = root;
            for (int i = 0; i < element.Length; i++)
            {
                if (!CurrentNode.nexts.ContainsKey(element[i]))
                {
                    CurrentNode.nexts[element[i]] = new BorNode();
                }
                CurrentNode.WordsWithSamePrefix++;
                CurrentNode = CurrentNode.nexts[element[i]];
            }
            CurrentNode.WordsWithSamePrefix++;
            CurrentNode.isTerminate = true;
            Size++;
            return true;   
        }
        /// <summary>
        /// Возвращает true, если элемент содержится в дереве. работает за O(|element|)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Contains(string element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (element == "")
            {
                return IsEmptyStringContained;
            }
            var CurrentNode = root;
            for (int i = 0; i < element.Length; i++)
            {
                if (!CurrentNode.nexts.ContainsKey(element[i]))
                {
                    return false;
                }
                CurrentNode = CurrentNode.nexts[element[i]];
            }
            if (CurrentNode.isTerminate == false) return false;
            return true;
        }
        /// <summary>
        /// Удаляет элемент из дерева.возвращает true, если элемент реально был в дереве, работает за O(|element|)
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(string element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (element == "")
            {
                if (!IsEmptyStringContained) return false;
                else
                {
                    IsEmptyStringContained = false;
                    return true;
                }
            }
            if (!Contains(element))
            {
                return false;
            }
            var CurrentNode = root;
            for (int i = 0; i < element.Length; i++)
            {
                CurrentNode = CurrentNode.nexts[element[i]];
                CurrentNode.WordsWithSamePrefix--;
            }
            CurrentNode.isTerminate = false;
            Size--;
            return true;
        }
        /// <summary>
        /// Возвращает количество строк в дереве начинающихся с этого префикса. работает за O(|prefix|). если prefix == "" бросает исключение.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public int HowManyStartsWithPrefix(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException();
            }
            if (prefix == "")
            {
                throw new Exception();
            }
            var CurrentNode = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!CurrentNode.nexts.ContainsKey(prefix[i]))
                {
                    return 0;
                }
                CurrentNode = CurrentNode.nexts[prefix[i]];
            }
            return CurrentNode.WordsWithSamePrefix;
        }
    }
}
