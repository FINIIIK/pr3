using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt3 {
    internal class Program {
        static void Main(string[] args) {
            var tree = TreeNode.CreateBalanced(7);
            Console.WriteLine();

            var average = TreeNode.Average(tree);
            Console.WriteLine("Cреднее арифметическое значений информационных полей узлов дерева: " + average);

            var number = 1; // Ввести для третьего пункта число которое необходимо проверять

            var positveNodes = TreeNode.PositiveNodesToList(tree, new List<int>());
            var negativeNodes = TreeNode.NegativeNodesToList(tree, new List<int>());

            Console.WriteLine("Количество узлов с положительным числом информационных полей: " + positveNodes.Count);
            Console.WriteLine("Количество узлов с отрицательным числом информационных полей: " + negativeNodes.Count);

            var containsNodes = TreeNode.ContainsNodesToList(tree, new List<int>(), number);
            Console.WriteLine("Число вхождений числа " + number + ": " + containsNodes.Count);

            Console.ReadKey();
        }
    }

    class TreeNode {
        public int Info { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public static void Show(TreeNode root) {
            if (root != null) {
                Console.WriteLine(root.Info);
                Show(root.Left);
                Show(root.Right);
            }
        }

        public static List<int> ToList(TreeNode root, List<int> list) {
            if (root != null) {
                list.Add(root.Info);
                ToList(root.Left, list);
                ToList(root.Right, list);
            }
            return list;
        }

        public static double Average(TreeNode root) {
            double average = 0;
            var list = ToList(root, new List<int>());

            foreach (var el in list) {
                average += el;
            }

            return average / list.Count;
        }

        public static List<int> PositiveNodesToList(TreeNode root, List<int> list) {
            if (root != null) {
                if (root.Info > 0) {
                    list.Add(root.Info);
                }

                PositiveNodesToList(root.Left, list);
                PositiveNodesToList(root.Right, list);
            }
            return list;
        }

        public static List<int> NegativeNodesToList(TreeNode root, List<int> list) {
            if (root != null) {
                if (root.Info < 0) {
                    list.Add(root.Info);
                }

                NegativeNodesToList(root.Left, list);
                NegativeNodesToList(root.Right, list);
            }
            return list;
        }

        public static List<int> ContainsNodesToList(TreeNode root, List<int> list, int contain) {
            if (root != null) {
                if (root.Info == contain) {
                    list.Add(root.Info);
                }

                ContainsNodesToList(root.Left, list, contain);
                ContainsNodesToList(root.Right, list, contain);
            }
            return list;
        }

        public static TreeNode CreateBalanced(int n) {

            int x;
            TreeNode root;
            if (n == 0)
                root = null;
            else {
                Console.Write("Dведите значение информационного поля узла: ");
                x = int.Parse(Console.ReadLine());
                root = new TreeNode() {
                    Info = x,
                };
                root.Left = CreateBalanced(n / 2);
                root.Right = CreateBalanced(n - n / 2 - 1);
            }
            return root;
        }
    }
}
