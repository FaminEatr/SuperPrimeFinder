using BottomlessLists;
using BottomlessIntegerNSA;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

// NEEDS A LOAD INFO OPTION
namespace SuperPrimeFinder
{
    public class MasterNumberGenerator
    {
        static BigList<DeepInteger> _first1kPrimes = new BigList<DeepInteger>
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987, 1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129, 2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287, 2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423, 2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617, 2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741, 2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903, 2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079, 3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257, 3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571, 3581, 3583, 3593, 3607, 3613, 3617, 3623, 3631, 3637, 3643, 3659, 3671, 3673, 3677, 3691, 3697, 3701, 3709, 3719, 3727, 3733, 3739, 3761, 3767, 3769, 3779, 3793, 3797, 3803, 3821, 3823, 3833, 3847, 3851, 3853, 3863, 3877, 3881, 3889, 3907, 3911, 3917, 3919, 3923, 3929, 3931, 3943, 3947, 3967, 3989, 4001, 4003, 4007, 4013, 4019, 4021, 4027, 4049, 4051, 4057, 4073, 4079, 4091, 4093, 4099, 4111, 4127, 4129, 4133, 4139, 4153, 4157, 4159, 4177, 4201, 4211, 4217, 4219, 4229, 4231, 4241, 4243, 4253, 4259, 4261, 4271, 4273, 4283, 4289, 4297, 4327, 4337, 4339, 4349, 4357, 4363, 4373, 4391, 4397, 4409, 4421, 4423, 4441, 4447, 4451, 4457, 4463, 4481, 4483, 4493, 4507, 4513, 4517, 4519, 4523, 4547, 4549, 4561, 4567, 4583, 4591, 4597, 4603, 4621, 4637, 4639, 4643, 4649, 4651, 4657, 4663, 4673, 4679, 4691, 4703, 4721, 4723, 4729, 4733, 4751, 4759, 4783, 4787, 4789, 4793, 4799, 4801, 4813, 4817, 4831, 4861, 4871, 4877, 4889, 4903, 4909, 4919, 4931, 4933, 4937, 4943, 4951, 4957, 4967, 4969, 4973, 4987, 4993, 4999, 5003, 5009, 5011, 5021, 5023, 5039, 5051, 5059, 5077, 5081, 5087, 5099, 5101, 5107, 5113, 5119, 5147, 5153, 5167, 5171, 5179, 5189, 5197, 5209, 5227, 5231, 5233, 5237, 5261, 5273, 5279, 5281, 5297, 5303, 5309, 5323, 5333, 5347, 5351, 5381, 5387, 5393, 5399, 5407, 5413, 5417, 5419, 5431, 5437, 5441, 5443, 5449, 5471, 5477, 5479, 5483, 5501, 5503, 5507, 5519, 5521, 5527, 5531, 5557, 5563, 5569, 5573, 5581, 5591, 5623, 5639, 5641, 5647, 5651, 5653, 5657, 5659, 5669, 5683, 5689, 5693, 5701, 5711, 5717, 5737, 5741, 5743, 5749, 5779, 5783, 5791, 5801, 5807, 5813, 5821, 5827, 5839, 5843, 5849, 5851, 5857, 5861, 5867, 5869, 5879, 5881, 5897, 5903, 5923, 5927, 5939, 5953, 5981, 5987, 6007, 6011, 6029, 6037, 6043, 6047, 6053, 6067, 6073, 6079, 6089, 6091, 6101, 6113, 6121, 6131, 6133, 6143, 6151, 6163, 6173, 6197, 6199, 6203, 6211, 6217, 6221, 6229, 6247, 6257, 6263, 6269, 6271, 6277, 6287, 6299, 6301, 6311, 6317, 6323, 6329, 6337, 6343, 6353, 6359, 6361, 6367, 6373, 6379, 6389, 6397, 6421, 6427, 6449, 6451, 6469, 6473, 6481, 6491, 6521, 6529, 6547, 6551, 6553, 6563, 6569, 6571, 6577, 6581, 6599, 6607, 6619, 6637, 6653, 6659, 6661, 6673, 6679, 6689, 6691, 6701, 6703, 6709, 6719, 6733, 6737, 6761, 6763, 6779, 6781, 6791, 6793, 6803, 6823, 6827, 6829, 6833, 6841, 6857, 6863, 6869, 6871, 6883, 6899, 6907, 6911, 6917, 6947, 6949, 6959, 6961, 6967, 6971, 6977, 6983, 6991, 6997, 7001, 7013, 7019, 7027, 7039, 7043, 7057, 7069, 7079, 7103, 7109, 7121, 7127, 7129, 7151, 7159, 7177, 7187, 7193, 7207, 7211, 7213, 7219, 7229, 7237, 7243, 7247, 7253, 7283, 7297, 7307, 7309, 7321, 7331, 7333, 7349, 7351, 7369, 7393, 7411, 7417, 7433, 7451, 7457, 7459, 7477, 7481, 7487, 7489, 7499, 7507, 7517, 7523, 7529, 7537, 7541, 7547, 7549, 7559, 7561, 7573, 7577, 7583, 7589, 7591, 7603, 7607, 7621, 7639, 7643, 7649, 7669, 7673, 7681, 7687, 7691, 7699, 7703, 7717, 7723, 7727, 7741, 7753, 7757, 7759, 7789, 7793, 7817, 7823, 7829, 7841, 7853, 7867, 7873, 7877, 7879, 7883, 7901, 7907, 7919
        };

        static string fileName = "SuperPrimeFinder_Results.txt";

        static List<NumberDefiner> definers = new List<NumberDefiner>();

        static bool functionStarted = false;

        static int Factor = 1;

        static DeepInteger targetIndex = 10000;

        static int targetNumber = int.MaxValue;
        static DeepInteger targetNDBackup;
        static DeepInteger targetNumberDeep;

        static int targetBatch = int.MaxValue;

        static int targetTimeInMinutes = 60;
        public static int targetParallels = 5;

        static DateTime beginTime;
        static DateTime endTime;
        static float minutesOperating;

        public static IntArray numbers;
        public static PrimeHunterArray ph_numbers;
        public static PrimeHunterInt One = new PrimeHunterInt(1);
        public static PrimeHunterInt Zero = new PrimeHunterInt(0);

        public static BigList<DeepInteger> PH_Primes = null;
        public static BigList<PrimeHunterInt> PH_SubPrimes = null;
        public static DeepInteger PH_ProcessedNumberCount = 0;

        public static PrimeArray primeNumbers = new PrimeArray();

        public static DeepInteger numberOfPrimes = 0;
        public static DeepInteger NumberOfPrimes
        {
            get
            {
                return numberOfPrimes;
            }

            set
            {
                numberOfPrimes = value;
            }
        }

        public static SubprimeArray subPrimeNumbers = new SubprimeArray();

        public static List<Batch> batches = new List<Batch>();

        static ExitCondition exitCondition = ExitCondition.INDEX;
        enum ExitCondition
        {
            INDEX,
            NUMBER,
            BATCH,
            DEFINEDNUMBER,
            TIME
        }

        private static PrimeHunterInt batchFirstPrime = new PrimeHunterInt(0);
        public static PrimeHunterInt BatchFirstPrime
        {
            get
            {
                return batchFirstPrime;
            }
            set
            {
                batchFirstPrime = value;
            }
        }

        private static DeepInteger ph_previousLCN = new PrimeHunterInt(0);
        public static DeepInteger PH_PreviousLCN
        {
            get
            {
                return ph_previousLCN;
            }
            set
            {
                ph_previousLCN = value;
            }
        }

        private static PrimeHunterInt batchLastPrime = new PrimeHunterInt(0);
        public static PrimeHunterInt BatchLastPrime
        {
            get
            {
                return batchLastPrime;
            }
            set
            {
                batchLastPrime = value;
            }
        }

        private static PrimeHunterInt _ph_lp = new PrimeHunterInt(2);
        public static PrimeHunterInt PH_LastPrime
        {
            get
            {
                return _ph_lp;
            }

            set
            {
                _ph_lp = value;
            }
        }

        public static PrimeHunterInt PH_LastContinuousNumber
        {
            get
            {
                if (ph_numbers.Length > 3)
                {
                    for (DeepInteger i = BatchLastPrime; i < ph_numbers.Length; ++i)
                    {
                        if (!i.Equals(ph_numbers[i]))
                        {
                            return new PrimeHunterInt(i - Factor);
                        }
                    }

                    return new PrimeHunterInt(ph_numbers[ph_numbers.Length - 1]);
                }
                return new PrimeHunterInt(2);
            }
        }

        static PrimeHunterInt ph_fnn;
        public static PrimeHunterInt PH_FirstNewNumber
        {
            get
            {
                return ph_fnn;
            }

            set
            {
                ph_fnn = value;
            }
        }

        static DeepInteger _lntd = 0;
        public static DeepInteger LargestNumberThisGeneration
        {
            get
            {
                return _lntd;
            }
        }
        public static void PH_SetLargestNumberThisGeneration(PrimeHunterInt value)
        {
            _lntd = new DeepInteger(value);
        }

        static DeepInteger _ngtg = 0;
        public static DeepInteger NumbersGeneratedThisGeneration
        {
            get
            {
                return _ngtg;
            }

            set
            {
                _ngtg = value;
            }
        }

        static DeepInteger _sntd = 0;
        public static DeepInteger SmallestNumberThisGeneration
        {
            get
            {
                return _sntd;
            }
        }
        private static ReaderWriterLockSlim sntdLock = new ReaderWriterLockSlim();
        public static void SetSmallestNumberThisGeneration(DeepInteger value, bool _override = false)
        {
            sntdLock.EnterWriteLock();
            try
            {
                if (value < _sntd || _override)
                {
                    _sntd = new DeepInteger(value);
                }
            }
            finally
            {
                sntdLock.ExitWriteLock();
            }
        }

        public static double CurrentRunningTime
        {
            get
            {
                return DateTime.UtcNow.Subtract(beginTime).TotalMinutes;
            }
        }

        public static void PH_AddToDefNumbers(PrimeHunterInt num)
        {
            ph_numbers.Add(num);
        }

        public static int batch = 0;

        public static bool _valid = false;
        public static bool RunValid()
        {
            bool valid = false;

            switch (exitCondition)
            {
                case ExitCondition.TIME:

                    if (CurrentRunningTime < targetTimeInMinutes &&
                          (batches[batch - 1].timeToProcessBatch * 2) + CurrentRunningTime < targetTimeInMinutes)
                    {
                        valid = true;
                    }

                    break;

                case ExitCondition.NUMBER:

                    if (PH_LastContinuousNumber < targetNumber)
                    {
                        valid = true;
                    }

                    break;

                case ExitCondition.BATCH:

                    if (batch < targetBatch)
                    {
                        valid = true;
                    }

                    break;

                case ExitCondition.DEFINEDNUMBER:

                    if (!targetNDBackup.Equals(targetNumberDeep))
                    {
                        targetNumberDeep = targetNDBackup;
                        targetNDBackup = new DeepInteger(targetNumberDeep);
                    }
                    if (null == ph_numbers || !ph_numbers.Contains(targetNumberDeep))
                    {
                        valid = true;
                    }

                    break;

                case ExitCondition.INDEX:
                default:

                    if (NumberOfPrimes < targetIndex)
                    {
                        valid = true;
                    }

                    break;
            }

            _valid = valid;
            return valid;
        }

        public static void CreateDefiner(int factor)
        {
            definers.Add(new NumberDefiner(factor));
        }

        private static int inputState = 2;

        private static IEnumerator Input()
        {
            bool downInc;
            string userIn;
            int intVal;
            PrimeHunterInt deepVal;
            int processorCount = Environment.ProcessorCount;

            while (inputState > 1)
            {
                userIn = "";
                intVal = 0;
                downInc = false;
                MasterNumberGenerator.targetParallels = processorCount - 1;

                Console.WriteLine("Enter Exit Condition:");
                Console.WriteLine("1 = Prime Number Index");
                Console.WriteLine("2 = Last Continuous Number Index");
                Console.WriteLine("3 = Batch Number");
                Console.WriteLine("4 = A Specific Defined Number");
                Console.WriteLine("5 = Running Time in Minutes");
                userIn = Console.ReadLine();

                if (userIn != string.Empty)
                {
                    intVal = Convert.ToInt32(userIn);

                    if (intVal > 0 && intVal < 6)
                    {
                        switch (intVal)
                        {
                            case 1:
                                exitCondition = ExitCondition.INDEX;
                                downInc = true;
                                break;

                            case 2:
                                exitCondition = ExitCondition.NUMBER;
                                downInc = true;
                                break;

                            case 3:
                                exitCondition = ExitCondition.BATCH;
                                downInc = true;
                                break;

                            case 4:
                                exitCondition = ExitCondition.DEFINEDNUMBER;
                                downInc = true;
                                break;

                            case 5:
                                exitCondition = ExitCondition.TIME;
                                downInc = true;
                                break;

                            default:
                                Console.WriteLine("Please enter a valid selection.");
                                break;
                        }

                        if (downInc)
                        {
                            --inputState;
                        }
                    }
                }

                Console.WriteLine();

                yield return null;
            }

            while (inputState == 1)
            {
                userIn = "";
                intVal = 0;
                downInc = false;

                switch (exitCondition)
                {
                    case ExitCondition.INDEX:
                        Console.WriteLine("Enter Desired Prime Index:");
                        userIn = Console.ReadLine();

                        if (userIn != string.Empty)
                        {
                            try
                            {
                                intVal = Convert.ToInt32(userIn);
                            }
                            catch { }

                            if (intVal > 0)
                            {
                                targetIndex = intVal;
                                downInc = true;
                            }
                        }
                        break;

                    case ExitCondition.NUMBER:
                        Console.WriteLine("Enter Desired Last Continuous Number:");
                        userIn = Console.ReadLine();

                        if (userIn != string.Empty)
                        {
                            intVal = Convert.ToInt32(userIn);

                            if (intVal > 0)
                            {
                                targetNumber = intVal;
                                downInc = true;
                            }
                        }
                        break;

                    case ExitCondition.BATCH:
                        Console.WriteLine("Enter Desired Batch Number:");
                        userIn = Console.ReadLine();

                        if (userIn != string.Empty)
                        {
                            intVal = Convert.ToInt32(userIn);

                            if (intVal > 0)
                            {
                                targetBatch = intVal + 1;
                                downInc = true;
                            }
                        }
                        break;

                    case ExitCondition.DEFINEDNUMBER:
                        Console.WriteLine("Enter Desired Defined Number:");
                        userIn = Console.ReadLine();

                        if (userIn != string.Empty)
                        {
                            deepVal = new PrimeHunterInt(userIn);

                            if (deepVal > 0)
                            {
                                targetNumberDeep = deepVal;
                                targetNDBackup = new DeepInteger(deepVal);
                                downInc = true;
                            }
                        }
                        break;

                    case ExitCondition.TIME:
                        Console.WriteLine("Enter Desired Run Time in Minutes:");
                        userIn = Console.ReadLine();

                        if (userIn != string.Empty)
                        {
                            intVal = Convert.ToInt32(userIn);

                            if (intVal > 0)
                            {
                                targetTimeInMinutes = intVal;
                                downInc = true;
                            }
                        }
                        break;

                    default:
                        break;
                }

                if (downInc)
                {
                    --inputState;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection.");
                }

                userIn = null;
                Console.WriteLine();
                yield return null;
            }

            yield break;
        }

        static void Main(string[] args)
        {
            // Input Conditions to set variables
            while (Input().MoveNext())
            {

            }

            if (!functionStarted)
            {
                Console.WriteLine("Settings Complete. Press Spacebar to Begin.");
                if (Console.ReadKey().Key.Equals(ConsoleKey.Spacebar))
                {
                    Console.WriteLine();
                    Console.WriteLine("~Running~");
                    if (null == definers || definers.Count < 1)
                    {
                        CreateDefiner(Factor);
                        functionStarted = true;
                        beginTime = DateTime.UtcNow;
                    }
                }
            }

            if (functionStarted)
            {
                while (RunValid())
                {
                    foreach (var definer in definers)
                    {
                        definer.Run();
                    }
                }

                endTime = DateTime.UtcNow;
                minutesOperating = MathF.Ceiling((float)endTime.Subtract(beginTime).TotalMinutes);
                functionStarted = false;

                // Output Data
                Console.WriteLine("~~~~~~~~~~~~~Elapsed Time~~~~~~~~~~~~~");
                Console.WriteLine(CurrentRunningTime);

                // Prime Number          Batch Number
                Dictionary<DeepInteger, DeepInteger> batchSieve = new Dictionary<DeepInteger, DeepInteger>();
                foreach (var batch in batches)
                {
                    if (!batchSieve.ContainsKey(batch.FirstPrime))
                    {
                        batchSieve.Add(new DeepInteger(batch.FirstPrime), new DeepInteger(batch.BatchNo));
                    }
                    if (!batchSieve.ContainsKey(batch.LastPrime))
                    {
                        batchSieve.Add(new DeepInteger(batch.LastPrime), new DeepInteger(batch.BatchNo));
                    }
                }

                PH_Primes = BigArrayUtilities.Sort(PH_Primes);

                DeepInteger max = PH_Primes.Count < 1000 ? PH_Primes.Count : 999;
                bool mismatchInFirst1k = false;

                for (DeepInteger i = 0; i < max; ++i)
                {
                    DeepInteger defPrime = PH_Primes[i];
                    DeepInteger estPrime = _first1kPrimes[i];

                    if (defPrime != estPrime)
                    {
                        mismatchInFirst1k = true;
                        Console.WriteLine("!!!!!PRIME MISMATCH!!!!!!");
                        break;
                    }
                }

                DeepInteger lastPrime = 0;
                DeepInteger batchNo = 1;
                DeepInteger batchIndex = 0;
                DeepInteger lastBatchNo = 1;
                DeepInteger lastBatchIndex = 0;
                float twinSetCount = 0;
                string lastBatchString = "";
                string batchString = "";

                using (StreamWriter file = File.CreateText(fileName))
                {
                    if (mismatchInFirst1k)
                    {
                        Console.WriteLine("!!!!!PRIME MISMATCH!!!!!!");
                    }
                    else
                    {
                        file.WriteLine("~~~~~~~~~~~~~Prime Numbers Defined~~~~~~~~~~~~~");
                        for (DeepInteger i = 0; i < PH_Primes.Length; ++i)
                        {
                            DeepInteger primeNumber = PH_Primes[i];

                            bool newBatch = false;
                            if (batchSieve.ContainsKey(primeNumber))
                            {
                                if (batchNo != batchSieve[primeNumber])
                                {
                                    newBatch = true;
                                    if (lastBatchNo == batchNo)
                                    {
                                        lastBatchNo = new DeepInteger(batchSieve[primeNumber]) - 1;
                                    }
                                    else
                                    {
                                        lastBatchNo = new DeepInteger(batchNo);
                                    }
                                    lastBatchIndex = lastBatchNo - 1;
                                    batchNo = new DeepInteger(batchSieve[primeNumber]);
                                    batchIndex = batchNo - 1;
                                }
                            }

                            lastBatchString = "Batch :" + lastBatchNo.ToString();
                            batchString = "Batch :" + batchNo.ToString();
                            if (newBatch)
                            {
                                file.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                file.WriteLine(lastBatchString + ". Twin sets this batch: " + twinSetCount);
                                file.WriteLine(lastBatchString + ". Primes this batch: " + batches[(int)lastBatchIndex].PrimesDefined);
                                file.WriteLine(lastBatchString + ". Smallest Prime this batch: " + batches[(int)lastBatchIndex].FirstPrime);
                                file.WriteLine(lastBatchString + ". Greatest Prime this batch: " + batches[(int)lastBatchIndex].LastPrime);
                                file.WriteLine(lastBatchString + ". Numbers this batch: " + batches[(int)lastBatchIndex].NumbersDefined);
                                file.WriteLine(lastBatchString + ". Smallest Number this batch: " + batches[(int)lastBatchIndex].FirstDefinedNum);
                                file.WriteLine(lastBatchString + ". Greatest Number this batch: " + batches[(int)lastBatchIndex].LastDefinedNum);
                                file.WriteLine();
                                file.WriteLine("Starting New Batch: " + batchString);
                                file.WriteLine("Prime Numbers");
                                file.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                twinSetCount = 0;
                            }

                            bool twin = false;
                            bool star = false;
                            if (lastPrime != 0)
                            {
                                DeepInteger diff = primeNumber - lastPrime;

                                if (diff == 2)
                                {
                                    twin = true;
                                    twinSetCount += 0.5f;
                                }

                                if ((i + 1) < PH_Primes.Length)
                                {
                                    diff = PH_Primes[i + 1] - primeNumber;
                                    if (diff == 2)
                                    {
                                        star = true;
                                        twinSetCount += 0.5f;
                                    }
                                }
                            }

                            lastPrime = primeNumber;

                            if (twin && !star)
                            {
                                file.WriteLine(primeNumber + " twin");
                            }
                            else if (!twin && star)
                            {
                                file.WriteLine(primeNumber + "   *");
                            }
                            else if (twin && star)
                            {
                                file.WriteLine(primeNumber + " twin *");
                            }
                            else
                            {
                                file.WriteLine(primeNumber);
                            }
                        }
                        file.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        file.WriteLine(batchString + ". Twin sets this batch: " + twinSetCount);
                        file.WriteLine(batchString + ". Primes this batch: " + batches[(int)batchIndex].PrimesDefined);
                        file.WriteLine(batchString + ". Smallest Prime this batch: " + batches[(int)batchIndex].FirstPrime);
                        file.WriteLine(batchString + ". Greatest Prime this batch: " + batches[(int)batchIndex].LastPrime);
                        file.WriteLine(batchString + ". Numbers this batch: " + batches[(int)batchIndex].NumbersDefined);
                        file.WriteLine(batchString + ". Smallest Number this batch: " + batches[(int)batchIndex].FirstDefinedNum);
                        file.WriteLine(batchString + ". Greatest Number this batch: " + batches[(int)batchIndex].LastDefinedNum);

                        file.WriteLine("~~~~~~~~~~~~~Total Amount of Numbers Defined~~~~~~~~~~~~~");
                        file.WriteLine(PH_ProcessedNumberCount);
                        file.WriteLine();
                        file.WriteLine();
                        file.WriteLine("~~~~~~~~~~~~~Factorization of Numbers Defined~~~~~~~~~~~~~~");

                        ph_numbers.SetStartPosition(3);
                        ph_numbers.SetIterationCap(LargestNumberThisGeneration);
                        IEnumerable<PrimeHunterInt> nums = ph_numbers.Where(i => !(i is null));
                        foreach (PrimeHunterInt _num in nums)
                        {
                            StringBuilder _sb = new StringBuilder("~!~" + _num.ToString() + " : " + _num.GetDefinition() + "~!~");
                            file.WriteLine(_sb.ToString());
                        }
                    }
                }

                foreach (var definer in definers)
                {
                    definer.CleanUp();
                }

                ph_numbers = null;
            }
        }
    }

    [Serializable]
    public class NumberDefiner
    {
        public NumberDefiner(int factor)
        {
            Factor = factor;
            NegFactor = new DeepInteger(Factor);
            NegFactor.isNegative = true;
            StartNewBatch();
        }

        DeepInteger Factor;
        DeepInteger NegFactor;

        IEnumerator _Batcher = null;
        IEnumerator _Generator = null;

        IEnumerator DefineNewNumbers()
        {
            if (null == MasterNumberGenerator.ph_numbers)
            {
                MasterNumberGenerator.ph_numbers = new PrimeHunterArray();
                MasterNumberGenerator.PH_Primes = new BigList<DeepInteger>();
                MasterNumberGenerator.PH_SubPrimes = new BigList<PrimeHunterInt>();
                Console.WriteLine("Double Multi Thread~");
            }

            MasterNumberGenerator.ph_numbers.UnprocessedNumberCount = new DeepInteger(0);
            MasterNumberGenerator.ph_numbers.UnprocessedPrimeCount = new DeepInteger(0);

            if (MasterNumberGenerator.ph_numbers.Length < 3)
            {
                MasterNumberGenerator.ph_numbers.UnprocessedNumberCount++;
                if (MasterNumberGenerator.ph_numbers.Length < 1)
                {
                    // Establish Reference of 0
                    PrimeHunterInt z = new PrimeHunterInt(0);
                    z.SetDefinition(ref MasterNumberGenerator.Zero, ref MasterNumberGenerator.Zero, true);
                    MasterNumberGenerator.PH_AddToDefNumbers(z);
                    MasterNumberGenerator.PH_FirstNewNumber = z;

                    MasterNumberGenerator.PH_ProcessedNumberCount++;
                    _Generator = null;
                    yield break;
                }
                else
                {
                    // Establish new mathematical functions
                    // i == 1 is 0 + 1 is Addition and Subtraction
                    // i == 2 is 1 + 1 and 1 * 2, giving Multiplication and Division
                    PrimeHunterInt ph_i = new PrimeHunterInt(MasterNumberGenerator.PH_FirstNewNumber + 1);
                    ph_i.SetDefinition(ref MasterNumberGenerator.One, ref ph_i, true);

                    if (ph_i == 2)
                    {
                        ph_i.IsPrime = true;
                        MasterNumberGenerator.PH_Primes.AddUnique(ph_i);
                        MasterNumberGenerator.ph_numbers.PrimeCount++;
                        MasterNumberGenerator.ph_numbers.UnprocessedPrimeCount++;
                        MasterNumberGenerator.BatchFirstPrime = ph_i;
                        MasterNumberGenerator.BatchLastPrime = ph_i;
                        ph_i.NextSet = true;
                    }

                    MasterNumberGenerator.PH_FirstNewNumber = ph_i;
                    MasterNumberGenerator.PH_AddToDefNumbers(ph_i);
                    MasterNumberGenerator.SetSmallestNumberThisGeneration(ph_i, true);
                    MasterNumberGenerator.PH_SetLargestNumberThisGeneration(ph_i);
                    MasterNumberGenerator.PH_ProcessedNumberCount++;
                    MasterNumberGenerator.PH_PreviousLCN = new DeepInteger(ph_i);
                    _Generator = null;
                    yield break;
                }
            }
            else
            {
                DeepInteger lcn = new DeepInteger(MasterNumberGenerator.PH_LastContinuousNumber);
                DeepInteger ceil = new DeepInteger(lcn * 2);
                DeepInteger nextLCN = new DeepInteger(ceil + 1);
                DeepInteger large = new DeepInteger(MasterNumberGenerator.LargestNumberThisGeneration);

                Console.Write("Last Continuous Number: " + lcn);
                Console.WriteLine();
                Console.Write("Ceiling: " + ceil);
                Console.WriteLine();
                Console.Write("Next LCN: " + nextLCN);
                Console.WriteLine();

                MasterNumberGenerator.ph_numbers.SetStartPosition(2);
                MasterNumberGenerator.ph_numbers.SetIterationCap(lcn);
                IEnumerable<PrimeHunterInt> firstEnumerable = (IEnumerable<PrimeHunterInt>)MasterNumberGenerator.ph_numbers.GetEnumerator(true);

                DeepInteger small = new DeepInteger(MasterNumberGenerator.SmallestNumberThisGeneration);

                MasterNumberGenerator.ph_numbers.SetStartPosition(small);
                MasterNumberGenerator.ph_numbers.SetIterationCap(large);

                IEnumerable<PrimeHunterInt> secondEnumerable = (IEnumerable<PrimeHunterInt>)MasterNumberGenerator.ph_numbers.GetEnumerator();
                HashSet<PrimeHunterInt> secondEnumHash = secondEnumerable.Where(f => !(f is null) && f.NextSet).ToHashSet();

                var innerPart = new SingleElementOrderablePartitioner<PrimeHunterInt>(secondEnumHash);

                DeepInteger unProcessedCount = new DeepInteger(0);

                foreach (var i in firstEnumerable)
                {
                    PrimeHunterInt m = MasterNumberGenerator.ph_numbers[i];
                    foreach (var k in secondEnumHash)
                    //Parallel.ForEach(innerPart, new ParallelOptions { MaxDegreeOfParallelism = MasterNumberGenerator.targetParallels }, k =>
                    {
                        if (k.NextSet)
                        {
                            PrimeHunterInt b = MasterNumberGenerator.ph_numbers[k];
                            PrimeHunterInt p = new PrimeHunterInt(b * m);

                            p.SetDefinition(ref m, ref b);

                            MasterNumberGenerator.PH_AddToDefNumbers(p);

                            if (b.IsPrime && m.IsPrime)
                            {
                                MasterNumberGenerator.ph_numbers[p].IsSubPrime = true;
                            }

                            unProcessedCount++;
                        }
                    }
                    //);

                    if (m >= small)
                    {
                        MasterNumberGenerator.ph_numbers[m].NextSet = true;
                    }
                    else
                    {
                        MasterNumberGenerator.ph_numbers[m].NextSet = false;
                    }
                }

                // between lcn and ceil
                //  if an array value is null, it's prime

                MasterNumberGenerator.ph_numbers.SetIterationCap(ceil);
                IEnumerable<DeepInteger> numsAbovePrimes = MasterNumberGenerator.ph_numbers.Where(i => !(i is null) && i >= lcn && i <= ceil && (MasterNumberGenerator.ph_numbers[i - 1] is null));

                DeepInteger firstPrimeIndex = numsAbovePrimes.First() - 1;
                DeepInteger lastPrimeIndex = numsAbovePrimes.Last() - 1;
                MasterNumberGenerator.BatchFirstPrime = new PrimeHunterInt(firstPrimeIndex);
                MasterNumberGenerator.BatchFirstPrime.IsPrime = true;
                MasterNumberGenerator.BatchLastPrime = new PrimeHunterInt(lastPrimeIndex);
                MasterNumberGenerator.BatchLastPrime.IsPrime = true;

                foreach (var _specialNum in numsAbovePrimes)
                //Parallel.ForEach(numsAbovePrimes, new ParallelOptions { MaxDegreeOfParallelism = MasterNumberGenerator.targetParallels }, _specialNum =>
                {
                    DeepInteger primeIndex = new DeepInteger(_specialNum - 1);
                    PrimeHunterInt newPrime = new PrimeHunterInt(primeIndex);
                    newPrime.IsPrime = true;
                    newPrime.NextSet = true;
                    MasterNumberGenerator.ph_numbers[primeIndex] = newPrime;
                    newPrime.SetDefinition(ref MasterNumberGenerator.One, ref newPrime);
                    MasterNumberGenerator.ph_numbers.UnprocessedPrimeCount++;
                    MasterNumberGenerator.ph_numbers.PrimeCount++;
                    MasterNumberGenerator.PH_Primes.AddUnique(newPrime);
                    unProcessedCount++;
                }
                //);

                MasterNumberGenerator.PH_PreviousLCN = new DeepInteger(lcn);

                MasterNumberGenerator.ph_numbers.UnprocessedNumberCount += unProcessedCount;
                MasterNumberGenerator.PH_ProcessedNumberCount += unProcessedCount;

                // This gets used next batch to determine the range of unprocessed numbers to be used.
                MasterNumberGenerator.SetSmallestNumberThisGeneration(lcn + 1, true);
                MasterNumberGenerator.PH_SetLargestNumberThisGeneration(MasterNumberGenerator.ph_numbers.Last());
                MasterNumberGenerator.PH_FirstNewNumber = new PrimeHunterInt(MasterNumberGenerator.SmallestNumberThisGeneration);
                _Generator = null;
                yield break;
            }
        }

        void StartNewBatch()
        {
            ++MasterNumberGenerator.batch;
            Batch newBatch = new Batch(MasterNumberGenerator.batch);
            MasterNumberGenerator.batches.Add(newBatch);
            newBatch.Start();
            _Generator = DefineNewNumbers();
        }

        IEnumerator Batch()
        {
            while (MasterNumberGenerator._valid)
            {
                if (null != _Generator && !_Generator.MoveNext())
                {
                    _Generator = null;
                }

                if (null == _Generator)
                {
                    if (null != MasterNumberGenerator.ph_numbers)
                    {
                        DeepInteger unc = new DeepInteger(MasterNumberGenerator.ph_numbers.UnprocessedNumberCount);
                        DeepInteger upc = new DeepInteger(MasterNumberGenerator.ph_numbers.UnprocessedPrimeCount);
                        if (null != MasterNumberGenerator.batches &&
                            MasterNumberGenerator.batches.Count > 0 &&
                            (MasterNumberGenerator.batch - 1 > -1) &&
                            null != MasterNumberGenerator.batches[MasterNumberGenerator.batch - 1])
                        {
                            MasterNumberGenerator.batches[MasterNumberGenerator.batch - 1].End(unc, upc,
                                MasterNumberGenerator.BatchFirstPrime, MasterNumberGenerator.BatchLastPrime,
                                MasterNumberGenerator.SmallestNumberThisGeneration, MasterNumberGenerator.LargestNumberThisGeneration);
                        }

                        MasterNumberGenerator.NumbersGeneratedThisGeneration = unc;
                    }
                    MasterNumberGenerator.NumberOfPrimes = new DeepInteger(MasterNumberGenerator.ph_numbers.PrimeCount);

                    Console.WriteLine();
                    Console.WriteLine("Batch Number: " + MasterNumberGenerator.batch);
                    Console.WriteLine("Prime Count: " + MasterNumberGenerator.NumberOfPrimes);
                    Console.WriteLine("Numbers Generated: " + MasterNumberGenerator.NumbersGeneratedThisGeneration);
                    Console.WriteLine("First Prime This Batch: " + MasterNumberGenerator.BatchFirstPrime);
                    Console.WriteLine("Last Prime This Batch: " + MasterNumberGenerator.BatchLastPrime);
                    Console.WriteLine("First Number This Batch: " + MasterNumberGenerator.SmallestNumberThisGeneration);
                    Console.WriteLine("Last Number This Batch: " + MasterNumberGenerator.LargestNumberThisGeneration);

                    StartNewBatch();
                }

                yield return null;
            }

            _Generator = null;

            _Batcher = null;

            MasterNumberGenerator.NumberOfPrimes = MasterNumberGenerator.PH_Primes.Count;

            yield break;
        }

        public void Run()
        {
            if (null == _Batcher)
            {
                _Batcher = Batch();
            }

            if (!_Batcher.MoveNext())
            {
                _Batcher = null;
            }
        }

        public void CleanUp()
        {
            _Generator = null;

            _Batcher = null;
        }
    }

    [Serializable]
    public class Batch
    {
        public float timeToProcessBatch = 0;

        private int batchNo = 0;
        public int BatchNo
        {
            get
            {
                return batchNo;
            }
        }
        private DeepInteger numbersDefinedThisBatch = 0;
        public DeepInteger NumbersDefined
        {
            get
            {
                return numbersDefinedThisBatch;
            }
        }

        private DeepInteger primesDefinedThisBatch = 0;
        public DeepInteger PrimesDefined
        {
            get
            {
                return primesDefinedThisBatch;
            }
        }

        private PrimeHunterInt firstPrimeThisBatch = new PrimeHunterInt(0);
        public PrimeHunterInt FirstPrime
        {
            get
            {
                return firstPrimeThisBatch;
            }
        }
        private PrimeHunterInt lastPrimeThisBatch = new PrimeHunterInt(0);
        public PrimeHunterInt LastPrime
        {
            get
            {
                return lastPrimeThisBatch;
            }
        }

        private DeepInteger firstNumThisBatch = 0;
        public DeepInteger FirstDefinedNum
        {
            get
            {
                return firstNumThisBatch;
            }
        }

        private DeepInteger lastNumThisBatch = 0;
        public DeepInteger LastDefinedNum
        {
            get
            {
                return lastNumThisBatch;
            }
        }

        private DateTime startTime;
        private DateTime endTime;

        public Batch(int batch)
        {
            batchNo = batch;
        }

        public void Start()
        {
            startTime = DateTime.UtcNow;
        }

        public void End(DeepInteger definedNums, DeepInteger definedPrimes,
            DeepInteger firstPrimeInBatch, DeepInteger lastPrimeInBatch,
            DeepInteger firstDefinedNum, DeepInteger lastDefinedNum)
        {
            numbersDefinedThisBatch = new DeepInteger(definedNums);
            primesDefinedThisBatch = new DeepInteger(definedPrimes);
            endTime = DateTime.UtcNow;
            timeToProcessBatch = MathF.Ceiling((float)endTime.Subtract(startTime).TotalMinutes);
            firstPrimeThisBatch = new PrimeHunterInt(firstPrimeInBatch);
            lastPrimeThisBatch = new PrimeHunterInt(lastPrimeInBatch);
            firstNumThisBatch = new DeepInteger(firstDefinedNum);
            lastNumThisBatch = new DeepInteger(lastDefinedNum);
        }
    }

    [Serializable]
    public class Definition<T, T1, T2>
    {
        public Definition(T _b, T1 _m, T2 _s)
        {
            _base = _b;
            _multiplier = _m;
            _subtractor = _s;
        }

        private T _base;
        public T Base { get { return _base; } set { _base = value; } }

        private T1 _multiplier;
        public T1 Multiplier { get { return _multiplier; } set { _multiplier = value; } }

        private T2 _subtractor;
        public T2 Subtractor { get { return _subtractor; } set { _subtractor = value; } }
    }

    [Serializable]
    public class IntArray : /*IEnumerator,*/ IEnumerable<DeepInteger>
    {
        public BigList<DeepInteger> _arr;

        public Dictionary<DeepInteger, List<Definition<DeepInteger, DeepInteger, DeepInteger>>> _definitions = null;

        //private int position = -1;
        private DeepInteger _defaultStartPos = 0;

        public IntArray()
        {
            _arr = new BigList<DeepInteger>();
        }

        public IntArray(DeepInteger[] arr)
        {
            _arr = new BigList<DeepInteger>(arr);
        }

        public IntArray(BigList<DeepInteger> arr)
        {
            _arr = new BigList<DeepInteger>(arr);
        }

        public IntArray(IntArray arr)
        {
            _arr = new BigList<DeepInteger>(arr._arr);
            _definitions = new Dictionary<DeepInteger, List<Definition<DeepInteger, DeepInteger, DeepInteger>>>(arr._definitions);
        }

        public DeepInteger this[DeepInteger index]
        {
            get
            {
                return _arr[index];
            }

            set
            {
                if (_arr._firstIndex is null ||
                    _arr._firstIndex > value)
                {
                    _arr._firstIndex = new DeepInteger(value);
                }
                _arr[index] = value;
            }
        }

        public DeepInteger Length
        {
            get
            {
                return _arr.Length;
            }
        }

        public void SetStartPosition(DeepInteger startPos)
        {
            _defaultStartPos = startPos;
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator(_arr._firstIndex);
        }

        IEnumerator<DeepInteger> IEnumerable<DeepInteger>.GetEnumerator()
        {
            return _arr.GetEnumerator(_defaultStartPos);
        }

        private ReaderWriterLockSlim addDefLock = new ReaderWriterLockSlim();
        public void AddDefinition(DeepInteger p, DeepInteger b, DeepInteger m, DeepInteger s)
        {
            if (_definitions is null)
            {
                _definitions = new Dictionary<DeepInteger, List<Definition<DeepInteger, DeepInteger, DeepInteger>>>();
            }
            Definition<DeepInteger, DeepInteger, DeepInteger> newDef = new Definition<DeepInteger, DeepInteger, DeepInteger>(b, m, s);
            Definition<DeepInteger, DeepInteger, DeepInteger> oppositeDef = new Definition<DeepInteger, DeepInteger, DeepInteger>(m, b, s);
            if (!_definitions.ContainsKey(p))
            {
                _definitions.Add(p, new List<Definition<DeepInteger, DeepInteger, DeepInteger>>());
            }
            _definitions[p].Add(newDef);
            _definitions[p].Add(oppositeDef);
        }

        private ReaderWriterLockSlim removeDefLock = new ReaderWriterLockSlim();
        public void RemoveDefinition(DeepInteger p, int s)
        {
            List<Definition<DeepInteger, DeepInteger, DeepInteger>> val = null;
            if (_definitions.TryGetValue(p, out val))
            {
                List<Definition<DeepInteger, DeepInteger, DeepInteger>> badDefs = new List<Definition<DeepInteger, DeepInteger, DeepInteger>>();

                foreach (var value in val)
                {
                    if (value.Subtractor.Equals(s))
                    {
                        badDefs.Add(value);
                    }
                }

                if (badDefs.Count > 0)
                {
                    foreach (var badDef in badDefs)
                    {
                        _definitions[p].Remove(badDef);
                    }
                }
            }
        }

        // Rework this plz
        //public List<DeepInteger> GetDefinition(DeepInteger num, List<DeepInteger> def)
        //{
        //    if (null == def)
        //    {
        //        def = new List<DeepInteger>();
        //    }

        //    if (_definitions.ContainsKey(num))
        //    {
        //        Definition<DeepInteger, DeepInteger, DeepInteger> numDef = _definitions[num][0];

        //        if (MasterNumberGenerator.IsPrime(numDef.Base) && MasterNumberGenerator.IsPrime(numDef.Multiplier))
        //        {
        //            def.Add(numDef.Base);
        //            def.Add(numDef.Multiplier);
        //        }
        //        else
        //        {
        //            if (!MasterNumberGenerator.IsPrime(numDef.Base))
        //            {
        //                def.AddRange(GetDefinition(numDef.Base, def));
        //            }
        //            else
        //            {
        //                def.Add(numDef.Base);
        //            }

        //            if (!MasterNumberGenerator.IsPrime(numDef.Multiplier))
        //            {
        //                def.AddRange(GetDefinition(numDef.Multiplier, def));
        //            }
        //            else
        //            {
        //                def.Add(numDef.Multiplier);
        //            }
        //        }
        //    }

        //    def.Sort();

        //    return def;
        //}

        private ReaderWriterLockSlim addLock = new ReaderWriterLockSlim();
        public void Add(DeepInteger i)
        {
            addLock.EnterWriteLock();
            try
            {
                _arr.EnsureCapacity(i + 1);

                if (_arr._firstIndex is null ||
                    _arr._firstIndex > i)
                {
                    _arr._firstIndex = new DeepInteger(i);
                }

                if (i > _arr.LastIndex)
                {
                    _arr.LastIndex = i;
                }

                _arr[i] = i;
            }
            finally
            {
                addLock.ExitWriteLock();
            }
        }
    }

    [Serializable]
    public class PrimeArray : IntArray
    {
        public PrimeArray()
        {
            _arr = new BigList<DeepInteger>();
        }
    }

    [Serializable]
    public class SubprimeArray : PrimeArray
    {
        public SubprimeArray()
        {
            _arr = new BigList<DeepInteger>();
        }
    }

    [Serializable]
    public class PrimeHunterArray : IEnumerable<PrimeHunterInt>
    {
        public BigList<PrimeHunterInt> _arr;

        public PrimeHunterArray()
        {
            _arr = new BigList<PrimeHunterInt>();
        }

        public PrimeHunterInt Last()
        {
            return _arr[_arr.LastIndex];
        }

        private DeepInteger _prnc = new DeepInteger(0);
        public DeepInteger PrimeCount
        {
            get
            {
                return _prnc;
            }

            set
            {
                _prnc = value;
            }
        }

        public BigList<PrimeHunterInt> Numbers
        {
            get
            {
                BigList<PrimeHunterInt> result = new BigList<PrimeHunterInt>();
                foreach (var i in _arr)
                {
                    if (!(i is null))
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        private DeepInteger _unc = new DeepInteger(0);
        public DeepInteger UnprocessedNumberCount
        {
            get
            {
                return _unc;
            }
            set
            {
                _unc = value;
            }
        }

        private DeepInteger _upc = new DeepInteger(0);
        public DeepInteger UnprocessedPrimeCount
        {
            get
            {
                return _upc;
            }

            set
            {
                _upc = value;
            }
        }

        public BigList<PrimeHunterInt> NumbersBetween(DeepInteger min, DeepInteger max, bool includeBounds = true)
        {
            BigList<PrimeHunterInt> result = new BigList<PrimeHunterInt>();
            if (includeBounds)
            {
                foreach (var i in Numbers)
                {
                    if (i >= min && i <= max)
                    {
                        result.Add(i);
                    }
                }
            }
            else
            {
                foreach (var i in Numbers)
                {
                    if (i > min && i < max)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        private DeepInteger _initStartPos;
        public DeepInteger InitialStartPosition
        {
            get
            {
                return _initStartPos;
            }
        }
        //private int position = -1;
        private DeepInteger _defaultStartPos = 0;

        public PrimeHunterInt this[DeepInteger index]
        {
            get
            {
                return _arr[index];
            }

            set
            {
                if (_arr._firstIndex is null ||
                    _arr._firstIndex > value)
                {
                    _arr._firstIndex = new DeepInteger(value);
                }
                _arr[index] = value;
            }
        }

        public DeepInteger Length
        {
            get
            {
                return _arr.Length;
            }
        }

        public void SetStartPosition(DeepInteger startPos)
        {
            if (_initStartPos is null)
            {
                if (!(_defaultStartPos is null))
                {
                    _initStartPos = new DeepInteger(_defaultStartPos);
                }
                else
                {
                    _initStartPos = new DeepInteger(startPos);
                }
            }
            _defaultStartPos = startPos;
        }
        public IEnumerator GetEnumerator(bool useDefaultIndex)
        {
            if (useDefaultIndex)
            {
                return _arr.GetEnumerator(_defaultStartPos);
            }
            return _arr.GetEnumerator(_arr._firstIndex);
        }

        public IEnumerator GetEnumerator()
        {
            return _arr.GetEnumerator(_arr._firstIndex);
        }

        IEnumerator<PrimeHunterInt> IEnumerable<PrimeHunterInt>.GetEnumerator()
        {
            return _arr.GetEnumerator(_defaultStartPos);
        }

        private ReaderWriterLockSlim addLock = new ReaderWriterLockSlim();
        public void Add(PrimeHunterInt i)
        {
            addLock.EnterWriteLock();
            try
            {
                _arr.EnsureCapacity(i + 1);

                if (_arr._firstIndex is null ||
                    _arr._firstIndex > i)
                {
                    _arr._firstIndex = new DeepInteger(i);
                }

                if (i > _arr.LastIndex)
                {
                    _arr.LastIndex = i;
                }

                if (_arr[i] is null)
                {
                    _arr[i] = i;
                }
            }
            finally
            {
                addLock.ExitWriteLock();
            }
        }

        public bool Contains(DeepInteger i)
        {
            if (i >= _arr.Length)
            {
                return false;
            }

            return !(_arr[i] is null) && _arr[i] == i;
        }

        public void SetLastIndex(DeepInteger index)
        {
            _arr.LastIndex = index;
        }

        internal void SetIterationCap(DeepInteger _cap)
        {
            _arr.SetIterationCap(_cap);
        }

        // Add ToJson()
        // Add FromJson()
        // Add FactorizeDefinition()
    }
}

// Simple partitioner that will extract one (index,item) pair at a time,
// in a thread-safe fashion, from the underlying collection.
class SingleElementOrderablePartitioner<T> : OrderablePartitioner<T>
{
    // The collection being wrapped by this Partitioner
    IEnumerable<T> m_referenceEnumerable;

    // Class used to wrap m_index for the purpose of sharing access to it
    // between an InternalEnumerable and multiple InternalEnumerators
    private class Shared<U>
    {
        internal U Value;

        public Shared(U item)
        {
            Value = item;
        }
    }

    // Internal class that serves as a shared enumerable for the
    // underlying collection.
    private class InternalEnumerable : IEnumerable<KeyValuePair<long, T>>, IDisposable
    {
        IEnumerator<T> m_reader;
        bool m_disposed = false;
        Shared<long> m_index = null;

        // These two are used to implement Dispose() when static partitioning is being performed
        int m_activeEnumerators;
        bool m_downcountEnumerators;

        // "downcountEnumerators" will be true for static partitioning, false for
        // dynamic partitioning.
        public InternalEnumerable(IEnumerator<T> reader, bool downcountEnumerators)
        {
            m_reader = reader;
            m_index = new Shared<long>(0);
            m_activeEnumerators = 0;
            m_downcountEnumerators = downcountEnumerators;
        }

        public IEnumerator<KeyValuePair<long, T>> GetEnumerator()
        {
            if (m_disposed)
                throw new ObjectDisposedException("InternalEnumerable: Can't call GetEnumerator() after disposing");

            // For static partitioning, keep track of the number of active enumerators.
            if (m_downcountEnumerators) Interlocked.Increment(ref m_activeEnumerators);

            return new InternalEnumerator(m_reader, this, m_index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<long, T>>)this).GetEnumerator();
        }

        public void Dispose()
        {
            if (!m_disposed)
            {
                // Only dispose the source enumerator if you are doing dynamic partitioning
                if (!m_downcountEnumerators)
                {
                    m_reader.Dispose();
                }
                m_disposed = true;
            }
        }

        // Called from Dispose() method of spawned InternalEnumerator.  During
        // static partitioning, the source enumerator will be automatically
        // disposed once all requested InternalEnumerators have been disposed.
        public void DisposeEnumerator()
        {
            if (m_downcountEnumerators)
            {
                if (Interlocked.Decrement(ref m_activeEnumerators) == 0)
                {
                    m_reader.Dispose();
                }
            }
        }
    }

    // Internal class that serves as a shared enumerator for
    // the underlying collection.
    private class InternalEnumerator : IEnumerator<KeyValuePair<long, T>>
    {
        KeyValuePair<long, T> m_current;
        IEnumerator<T> m_source;
        InternalEnumerable m_controllingEnumerable;
        Shared<long> m_index = null;
        bool m_disposed = false;

        public InternalEnumerator(IEnumerator<T> source, InternalEnumerable controllingEnumerable, Shared<long> index)
        {
            m_source = source;
            m_current = default(KeyValuePair<long, T>);
            m_controllingEnumerable = controllingEnumerable;
            m_index = index;
        }

        object IEnumerator.Current
        {
            get { return m_current; }
        }

        KeyValuePair<long, T> IEnumerator<KeyValuePair<long, T>>.Current
        {
            get { return m_current; }
        }

        void IEnumerator.Reset()
        {
            throw new NotSupportedException("Reset() not supported");
        }

        // This method is the crux of this class.  Under lock, it calls
        // MoveNext() on the underlying enumerator, grabs Current and index,
        // and increments the index.
        bool IEnumerator.MoveNext()
        {
            bool rval = false;
            lock (m_source)
            {
                rval = m_source.MoveNext();
                if (rval)
                {
                    m_current = new KeyValuePair<long, T>(m_index.Value, m_source.Current);
                    m_index.Value = m_index.Value + 1;
                }
                else
                {
                    m_current = default(KeyValuePair<long, T>);
                }
            }
            return rval;
        }

        void IDisposable.Dispose()
        {
            if (!m_disposed)
            {
                // Delegate to parent enumerable's DisposeEnumerator() method
                m_controllingEnumerable.DisposeEnumerator();
                m_disposed = true;
            }
        }
    }

    // Constructor just grabs the collection to wrap
    public SingleElementOrderablePartitioner(IEnumerable<T> enumerable)
        : base(true, true, true)
    {
        // Verify that the source IEnumerable is not null
        if (enumerable == null)
            throw new ArgumentNullException("enumerable");

        m_referenceEnumerable = enumerable;
    }

    // Produces a list of "numPartitions" IEnumerators that can each be
    // used to traverse the underlying collection in a thread-safe manner.
    // This will return a static number of enumerators, as opposed to
    // GetOrderableDynamicPartitions(), the result of which can be used to produce
    // any number of enumerators.
    public override IList<IEnumerator<KeyValuePair<long, T>>> GetOrderablePartitions(int numPartitions)
    {
        if (numPartitions < 1)
            throw new ArgumentOutOfRangeException("NumPartitions");

        List<IEnumerator<KeyValuePair<long, T>>> list = new List<IEnumerator<KeyValuePair<long, T>>>(numPartitions);

        // Since we are doing static partitioning, create an InternalEnumerable with reference
        // counting of spawned InternalEnumerators turned on.  Once all of the spawned enumerators
        // are disposed, dynamicPartitions will be disposed.
        var dynamicPartitions = new InternalEnumerable(m_referenceEnumerable.GetEnumerator(), true);
        for (int i = 0; i < numPartitions; i++)
            list.Add(dynamicPartitions.GetEnumerator());

        return list;
    }

    // Returns an instance of our internal Enumerable class.  GetEnumerator()
    // can then be called on that (multiple times) to produce shared enumerators.
    public override IEnumerable<KeyValuePair<long, T>> GetOrderableDynamicPartitions()
    {
        // Since we are doing dynamic partitioning, create an InternalEnumerable with reference
        // counting of spawned InternalEnumerators turned off.  This returned InternalEnumerable
        // will need to be explicitly disposed.
        return new InternalEnumerable(m_referenceEnumerable.GetEnumerator(), false);
    }

    // Must be set to true if GetDynamicPartitions() is supported.
    public override bool SupportsDynamicPartitions
    {
        get { return true; }
    }
}

class OrderableListPartitioner<TSource> : OrderablePartitioner<TSource>
{
    private readonly IList<TSource> m_input;

    // Must override to return true.
    public override bool SupportsDynamicPartitions => true;

    public OrderableListPartitioner(IList<TSource> input) : base(true, false, true) =>
        m_input = input;

    public override IList<IEnumerator<KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount)
    {
        var dynamicPartitions = GetOrderableDynamicPartitions();
        var partitions =
            new IEnumerator<KeyValuePair<long, TSource>>[partitionCount];

        for (int i = 0; i < partitionCount; i++)
        {
            partitions[i] = dynamicPartitions.GetEnumerator();
        }
        return partitions;
    }

    public override IEnumerable<KeyValuePair<long, TSource>> GetOrderableDynamicPartitions() =>
        new ListDynamicPartitions(m_input);

    private class ListDynamicPartitions : IEnumerable<KeyValuePair<long, TSource>>
    {
        private IList<TSource> m_input;
        private int m_pos = 0;

        internal ListDynamicPartitions(IList<TSource> input) =>
            m_input = input;

        public IEnumerator<KeyValuePair<long, TSource>> GetEnumerator()
        {
            while (true)
            {
                // Each task gets the next item in the list. The index is
                // incremented in a thread-safe manner to avoid races.
                int elemIndex = Interlocked.Increment(ref m_pos) - 1;

                if (elemIndex >= m_input.Count)
                {
                    yield break;
                }

                yield return new KeyValuePair<long, TSource>(
                    elemIndex, m_input[elemIndex]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable<KeyValuePair<long, TSource>>)this).GetEnumerator();
    }
}

public class PrimeHunterInt : DeepInteger
{
    private bool _isPrime = false;
    public bool IsPrime
    {
        get
        {
            return _isPrime;
        }
        set
        {
            _isPrime = value;
        }
    }
    private bool _isSubPrime = false;
    public bool IsSubPrime
    {
        get
        {
            return _isSubPrime;
        }
        set
        {
            _isSubPrime = value;
        }
    }
    private bool _nextSet = false;
    public bool NextSet
    {
        get
        {
            return _nextSet;
        }
        set
        {
            _nextSet = value;
        }
    }

    private bool _firstDefSet = false;
    public bool FirstDefSet
    {
        get
        {
            return _firstDefSet;
        }
    }
    private PrimeHunterInt _definitionBase = null;
    private PrimeHunterInt _definitionMult = null;

    public void SetDefinition(ref PrimeHunterInt _b, ref PrimeHunterInt _m, bool ignoreSetDef = false)
    {
        if (!_firstDefSet && !ignoreSetDef)
        {
            _definitionBase = _b;
            _definitionMult = _m;
            _firstDefSet = true;
        }
    }
    public string GetDefinition(StringBuilder _sb = null)
    {
        bool downLength = false;
        if (_sb is null)
        {
            _sb = new StringBuilder();
            downLength = true;
        }

        if (IsPrime)
        {
            _sb.Append(ToString() + "*");
        }
        else
        {
            if (_definitionBase is null)
            {
                if (this.Equals(Zero))
                {
                    _sb.Append("0*");
                }
                else
                {
                    _sb.Append("1*");
                }
            }
            else
            {
                _definitionBase.GetDefinition(_sb);
            }

            if (_definitionMult is null)
            {
                if (this.Equals(Zero))
                {
                    _sb.Append("0*");
                }
                else
                {
                    _sb.Append("1*");
                }
            }
            else
            {
                _definitionMult.GetDefinition(_sb);
            }
        }

        if (downLength)
        {
            _sb.Length--;
        }

        return (FirstDefSet && null != _sb) ? _sb.ToString() : "";
    }

    public PrimeHunterInt(string val) : base(val)
    {

    }

    public PrimeHunterInt(DeepInteger val) : base(val)
    {
    }

    public PrimeHunterInt(PrimeHunterInt val) : base(val)
    {
        IsPrime = val.IsPrime;
        IsSubPrime = val.IsSubPrime;
    }

    public PrimeHunterInt(int placeNumVal) : base(placeNumVal)
    {
    }
}
