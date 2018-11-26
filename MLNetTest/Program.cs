using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Models;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Runtime.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ColumnAttribute = Microsoft.ML.Runtime.Api.ColumnAttribute;


using Microsoft.ML;
using Microsoft.ML.Runtime;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
namespace MLNetTest
{
    class Program
    {
        const string _dataPath = @".\data\poker-hand-training-true.data";
        const string _testDataPath = @".\data\poker-hand-testing.data";

        public class PokerHandData
        {
            IEnumerable<int> cards = null;
            IDictionary<int, int> valueCounts = null;

            [Column(ordinal: "0")]
            public float S1;
            [Column(ordinal: "1")]
            public float C1;
            [Column(ordinal: "2")]
            public float S2;
            [Column(ordinal: "3")]
            public float C2;
            [Column(ordinal: "4")]
            public float S3;
            [Column(ordinal: "5")]
            public float C3;
            [Column(ordinal: "6")]
            public float S4;
            [Column(ordinal: "7")]
            public float C4;
            [Column(ordinal: "8")]
            public float S5;
            [Column(ordinal: "9")]
            public float C5;
            [Column(ordinal: "10", name: "Label")]
            public float Power;
            [Column(ordinal: "11")]
            public float IsSameSuit;

            [Column(ordinal: "12")]
            public float IsStraight;

            [Column(ordinal: "13")]
            public float FourOfKind;

            [Column(ordinal: "14")]
            public float ThreeOfKind;

            [Column(ordinal: "15")]
            public float PairsCount;

            public float GetIsSameSuit()
            {
                if (S1 == S2 && S2 == S3 && S3 == S4 && S4 == S5)
                    return 1;
                else
                    return 0;
            }

            public float GetIsStraight()
            {
                var keys = GetCards().ToArray();
                Array.Sort(keys);
                if (keys[1] - keys[0] == keys[2] - keys[1] && keys[2] - keys[1] == keys[3] - keys[2] && keys[3] - keys[2] == keys[4] - keys[3] && keys[4] - keys[3] == 1)
                {
                    return 1;
                }
                else if (keys[0] == 1 && keys[1] == 10 && keys[2] == 11 && keys[3] == 12 && keys[4] == 13)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            public float GetFourOfKind()
            {
                return GetCountOfCondition(4);
            }

            public float GetThreeOfKind()
            {
                return GetCountOfCondition(3);
            }

            public float GetPairsCount()
            {
                return GetCountOfCondition(2);
            }

            private IEnumerable<int> GetCards()
            {
                if (cards == null)
                {
                    cards = new[] { Convert.ToInt32(C1), Convert.ToInt32(C2), Convert.ToInt32(C3), Convert.ToInt32(C4), Convert.ToInt32(C5) };
                }

                return cards;
            }

            private float GetCountOfCondition(int target)
            {
                if (valueCounts == null)
                {
                    valueCounts = GetValueCountsOfCondition(GetCards());
                }

                return valueCounts.Count(i => i.Value == target);
            }

            public void Init()
            {
                IsSameSuit = GetIsSameSuit();
                IsStraight = GetIsStraight();
                FourOfKind = GetFourOfKind();
                ThreeOfKind = GetThreeOfKind();
                PairsCount = GetPairsCount();
            }
        }

        static Dictionary<int, int> GetValueCountsOfCondition(IEnumerable<int> cards)
        {
            var dic = new Dictionary<int, int>();

            foreach (var item in cards)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item] += 1;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            return dic;
        }

        static string GetSuitOfCard(float num)
        {
            var suit = string.Empty;
            switch (num)
            {
                case 1:
                    suit = "红心";
                    break;
                case 2:
                    suit = "黑桃";
                    break;
                case 3:
                    suit = "方块";
                    break;
                case 4:
                    suit = "梅花";
                    break;
            }
            return suit;
        }

        static string GetRankOfCard(float num)
        {
            var suit = string.Empty;
            switch ((int)num)
            {
                case int n when n == 1:
                    suit = "A";
                    break;
                case int n when n <= 10:
                    suit = n.ToString();
                    break;
                case int n when n == 11:
                    suit = "J";
                    break;
                case int n when n == 12:
                    suit = "Q";
                    break;
                case int n when n == 13:
                    suit = "K";
                    break;

            }
            return suit;
        }

        static string GetPower(float[] nums)
        {
            var index = -1;
            var last = 0F;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > last)
                {
                    index = i;
                    last = nums[i];
                }
            }

            var suit = string.Empty;
            switch (index)
            {
                case 0:
                    suit = "高牌";
                    break;
                case 1:
                    suit = "一对";
                    break;
                case 2:
                    suit = "两对";
                    break;
                case 3:
                    suit = "三条";
                    break;
                case 4:
                    suit = "顺子";
                    break;
                case 5:
                    suit = "同花";
                    break;
                case 6:
                    suit = "葫芦";
                    break;
                case 7:
                    suit = "四条";
                    break;
                case 8:
                    suit = "同花顺";
                    break;
                case 9:
                    suit = "皇家同花顺";
                    break;

            }
            return suit;
        }

        static string ShowHand(PokerHandData data)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}{1} {2}{3} {4}{5} {6}{7} {8}{9}", GetSuitOfCard(data.S1), GetRankOfCard(data.C1),
                                                                  GetSuitOfCard(data.S2), GetRankOfCard(data.C2),
                                                                  GetSuitOfCard(data.S3), GetRankOfCard(data.C3),
                                                                  GetSuitOfCard(data.S4), GetRankOfCard(data.C4),
                                                                  GetSuitOfCard(data.S5), GetRankOfCard(data.C5));
            return sb.ToString();
        }

        public class PokerHandPrediction
        {
            [ColumnName("Score")]
            public float[] PredictedPower;
        }

        public static PredictionModel<PokerHandData, PokerHandPrediction> Train(IEnumerable<PokerHandData> data)
        {
            var pipeline = new LearningPipeline();
            var collection = CollectionDataSource.Create(data);
            pipeline.Add(collection);
            pipeline.Add(new ColumnConcatenator("Features", "IsSameSuit", "IsStraight", "FourOfKind", "ThreeOfKind", "PairsCount"));
            pipeline.Add(new LogisticRegressionClassifier());
            var model = pipeline.Train<PokerHandData, PokerHandPrediction>();
            return model;
        }

        public static void Evaluate(PredictionModel<PokerHandData, PokerHandPrediction> model, IEnumerable<PokerHandData> data)
        {
            var evaluator = new ClassificationEvaluator();
            var collection = CollectionDataSource.Create(data);
            var metrics = evaluator.Evaluate(model, collection);
            Console.WriteLine();
            Console.WriteLine("PredictionModel quality metrics evaluation");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"LogLossReduction: {metrics.LogLossReduction }");
            Console.WriteLine($"LogLoss: {metrics.LogLoss }");
        }

        public static void Predict(PredictionModel<PokerHandData, PokerHandPrediction> model)
        {
            var test1 = new PokerHandData
            {
                S1 = 1,
                C1 = 2,
                S2 = 1,
                C2 = 3,
                S3 = 3,
                C3 = 4,
                S4 = 4,
                C4 = 5,
                S5 = 2,
                C5 = 6
            };

            var test2 = new PokerHandData
            {
                S1 = 4,
                C1 = 5,
                S2 = 1,
                C2 = 5,
                S3 = 3,
                C3 = 5,
                S4 = 2,
                C4 = 12,
                S5 = 4,
                C5 = 7
            };
            test1.Init();
            test2.Init();
            IEnumerable<PokerHandData> pokerHands = new[]
            {
                test1,
                test2
            };
            IEnumerable<PokerHandPrediction> predictions = model.Predict(pokerHands);
            Console.WriteLine();
            Console.WriteLine("PokerHand Predictions");
            Console.WriteLine("---------------------");

            var pokerHandsAndPredictions = pokerHands.Zip(predictions, (pokerHand, prediction) => (pokerHand, prediction));
            foreach (var (pokerHand, prediction) in pokerHandsAndPredictions)
            {
                Console.WriteLine($"PokerHand: {ShowHand(pokerHand)} | Prediction: { GetPower(prediction.PredictedPower)}");
            }
            Console.WriteLine();

        }
        static IEnumerable<PokerHandData> LoadData(string path)
        {
            using (var environment = new TlcEnvironment())
            {
                var pokerHandData = new List<PokerHandData>();
                var textLoader = new Microsoft.ML.Data.TextLoader(path).CreateFrom<PokerHandData>(useHeader: false, separator: ',', trimWhitespace: false);
                var experiment = environment.CreateExperiment();
                var output = textLoader.ApplyStep(null, experiment) as ILearningPipelineDataStep;

                experiment.Compile();
                textLoader.SetInput(environment, experiment);
                experiment.Run();

                var data = experiment.GetOutput(output.Data);

                using (var cursor = data.GetRowCursor((a => true)))
                {
                    var getters = new ValueGetter<float>[]{
                        cursor.GetGetter<float>(0),
                        cursor.GetGetter<float>(1),
                        cursor.GetGetter<float>(2),
                        cursor.GetGetter<float>(3),
                        cursor.GetGetter<float>(4),
                        cursor.GetGetter<float>(5),
                        cursor.GetGetter<float>(6),
                        cursor.GetGetter<float>(7),
                        cursor.GetGetter<float>(8),
                        cursor.GetGetter<float>(9),
                        cursor.GetGetter<float>(10)
                    };

                    while (cursor.MoveNext())
                    {

                        float value0 = 0;
                        float value1 = 0;
                        float value2 = 0;
                        float value3 = 0;
                        float value4 = 0;
                        float value5 = 0;
                        float value6 = 0;
                        float value7 = 0;
                        float value8 = 0;
                        float value9 = 0;
                        float value10 = 0;
                        getters[0](ref value0);
                        getters[1](ref value1);
                        getters[2](ref value2);
                        getters[3](ref value3);
                        getters[4](ref value4);
                        getters[5](ref value5);
                        getters[6](ref value6);
                        getters[7](ref value7);
                        getters[8](ref value8);
                        getters[9](ref value9);
                        getters[10](ref value10);

                        var hands = new PokerHandData()
                        {
                            S1 = value0,
                            C1 = value1,
                            S2 = value2,
                            C2 = value3,
                            S3 = value4,
                            C3 = value5,
                            S4 = value6,
                            C4 = value7,
                            S5 = value8,
                            C5 = value9,
                            Power = value10
                        };
                        hands.Init();
                        pokerHandData.Add(hands);
                    }
                }

                return pokerHandData;
            }
        }

        static void Main(string[] args)
        {
            var data = LoadData(_dataPath);
            var model = Train(data);
            var testData = LoadData(_dataPath);
            Evaluate(model, testData);
            Predict(model);
        }
    }
}
