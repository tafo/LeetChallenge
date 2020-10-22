using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Challenge.Leet.October.AsteroidCollision
{
    /// <summary>
    /// https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3502/
    /// </summary>
    public class Solution
    {
        public int[] AsteroidCollisionWithoutStack(int[] asteroids)
        {
            for (var i = 0; i < asteroids.Length; i++)
            {
                var asteroid = asteroids[i];
                if (asteroid >= 0) continue;
                var k = i;
                do
                {
                    k--;
                } while (k >= 0 && asteroids[k] <= 0);

                if (k < 0) continue;

                if (asteroids[k] > Math.Abs(asteroids[i]))
                {
                    asteroids[i] = 0;
                }
                else if (asteroids[k] < Math.Abs(asteroids[i]))
                {
                    asteroids[k] = 0;
                    i--;
                }
                else
                {
                    asteroids[i] = 0;
                    asteroids[k] = 0;
                    i--;
                }
            }

            return asteroids.Where(x => x != 0).ToArray();
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            var asteroidStack = new Stack<int>();
            foreach (var asteroid in asteroids)
            {
                if (asteroid < 0)
                {
                    if (asteroidStack.Count == 0 || asteroidStack.Peek() < 0)
                    {
                        asteroidStack.Push(asteroid);
                    }
                    else
                    {
                        var pushedAsteroid = 0;
                        var absoluteAsteroid = Math.Abs(asteroid);
                        while (asteroidStack.Count > 0 && asteroidStack.Peek() > 0)
                        {
                            pushedAsteroid = asteroidStack.Pop();
                            if (pushedAsteroid < absoluteAsteroid)
                            {
                                continue;
                            }

                            if (pushedAsteroid == absoluteAsteroid)
                            {
                                break;
                            }
                            asteroidStack.Push(pushedAsteroid);
                            break;
                        }

                        if (pushedAsteroid < absoluteAsteroid)
                        {
                            asteroidStack.Push(asteroid);
                        }
                    }
                }
                else
                {
                    asteroidStack.Push(asteroid);
                }
            }

            return asteroidStack.Reverse().ToArray();
        }
    }
}