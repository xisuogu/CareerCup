from functools import reduce

class AppliedMath:
    """description of class"""
    def Question1_Fibonacci(self):
        fib = self.Fib()
        for i in range(11):
            print(next(fib)) # in python 3, fib.next() is deprecated, use next(generator)

    def Fib(self):
        a, b = 0, 1
        while (True):
            yield a
            a , b = a + b, a

    # brute force
    def Question2_Count2_Method1(self, number):
        return sum([str(s).count('2') for s in range(1, number+1)])

    # brute force
    def Question5_Count_Trailing_Zero_Method1(self, number):
        fact = reduce(lambda x, y : x * y, range(1, number+1)) # python's reduce (in functools) and lamdba usage!
        return len(str(fact)) - len(str(fact).rstrip('0'))
    
    # count '5'
    def Question5_Count_Trailing_Zero_Method2(self, number):
        ans, tmp = 0, 5
        while (number >= tmp):
            ans += number // tmp # // is devide + remainder
            tmp *= 5
        return ans
            




