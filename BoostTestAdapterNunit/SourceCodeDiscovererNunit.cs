﻿// (C) Copyright ETAS 2015.
// Distributed under the Boost Software License, Version 1.0.
// (See accompanying file LICENSE_1_0.txt or copy at
// http://www.boost.org/LICENSE_1_0.txt)

using System.Collections.Generic;
using System.Linq;
using BoostTestAdapter.Discoverers;
using BoostTestAdapter.SourceFilter;
using BoostTestAdapter.Utility;
using BoostTestAdapter.Utility.VisualStudio;
using BoostTestAdapterNunit.Fakes;
using BoostTestAdapterNunit.Utility;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using QualifiedNameBuilder = BoostTestAdapter.Utility.QualifiedNameBuilder;

namespace BoostTestAdapterNunit
{
    [TestFixture]
    internal class SourceCodeDiscovererNunit
    {
        #region Test Setup/TearDown

        [SetUp]
        public void SetUp()
        {
            Logger.Initialize(new ConsoleMessageLogger());
        }

        [TearDown]
        public void TearDown()
        {
            Logger.Shutdown();
        }

        #endregion Test Setup/TearDown

        #region Test Data

        private const string DefaultSource = "TestCaseCheck.exe";

        #endregion Test Data

        #region Helper Methods

        /// <summary>
        /// Applies the discovery process over the provided DummySolution
        /// </summary>
        /// <param name="solution">The dummy solution on which to apply test discovery</param>
        /// <returns>The list of tests which were discovered from the dummy solution</returns>
        private IList<TestCase> DiscoverTests(DummySolution solution)
        {
            DefaultTestCaseDiscoverySink discoverySink = new DefaultTestCaseDiscoverySink();

            ISourceFilter[] filters = new ISourceFilter[]
            {
                new QuotedStringsFilter(),
                new MultilineCommentFilter(),
                new SingleLineCommentFilter(),
                new ConditionalInclusionsFilter(new ExpressionEvaluation())
            };

            SourceCodeDiscoverer discoverer = new SourceCodeDiscoverer(solution.Provider);
            discoverer.DiscoverTests(new []{solution.Source}, new DefaultTestContext(true), discoverySink);

            return discoverySink.Tests.ToList();
        }

        /// <summary>
        /// Assert that a trait with the provided name exists.
        /// </summary>
        /// <param name="testCase">The testcase which contains the trait collection in question</param>
        /// <param name="name">The name of the trait to look for</param>
        private void AssertTrait(TestCase testCase, string name)
        {
            Assert.That(testCase.Traits.Any((trait) => { return (trait.Name == name); }), Is.True);
        }

        /// <summary>
        /// Assert that a trait with the provided name and value exists.
        /// </summary>
        /// <param name="testCase">The testcase which contains the trait collection in question</param>
        /// <param name="name">The name of the trait to look for</param>
        /// <param name="value">The value the looked-up trait should have</param>
        private void AssertTrait(TestCase testCase, string name, string value)
        {
            Assert.That(testCase.Traits.Any((trait) => { return (trait.Name == name) && (trait.Value == value); }), Is.True);
        }

        /// <summary>
        /// Assert that a 'TestSuite' trait with the provided value exists.
        /// </summary>
        /// <param name="testCase">The testcase which contains the trait collection in question</param>
        /// <param name="value">The test suite value the looked-up trait should have</param>
        private void AssertTestSuite(TestCase testCase, string value)
        {
            AssertTrait(testCase, VSTestModel.TestSuiteTrait, value);
        }

        /// <summary>
        /// Asserts general test case details
        /// </summary>
        /// <param name="testCase">The test case to test</param>
        /// <param name="qualifiedName">The expected qualified name of the test case</param>
        private void AssertTestDetails(TestCase testCase, QualifiedNameBuilder qualifiedName)
        {
            AssertTestDetails(testCase, qualifiedName, null, -1);
        }

        /// <summary>
        /// Asserts general test case details
        /// </summary>
        /// <param name="testCase">The test case to test</param>
        /// <param name="qualifiedName">The expected qualified name of the test case</param>
        /// <param name="sourceFile">The expected source file path of the test case or null if not available</param>
        /// <param name="lineNumber">The expected line number of the test case or -1 if not available</param>
        private void AssertTestDetails(TestCase testCase, QualifiedNameBuilder qualifiedName, string sourceFile, int lineNumber)
        {
            Assert.That(testCase.DisplayName, Is.EqualTo(qualifiedName.Peek()));
            Assert.That(testCase.FullyQualifiedName, Is.EqualTo(qualifiedName.ToString()));

            string suite = qualifiedName.Pop().ToString();
            if (!string.IsNullOrEmpty(suite))
            {
                AssertTestSuite(testCase, suite);
            }
            else
            {
                // The default 'Master Test Suite' trait value should be available
                AssertTrait(testCase, VSTestModel.TestSuiteTrait);
            }

            if (!string.IsNullOrEmpty(sourceFile))
            {
                Assert.That(testCase.CodeFilePath, Is.EqualTo(sourceFile));
            }

            if (lineNumber > -1)
            {
                Assert.That(testCase.LineNumber, Is.EqualTo(lineNumber));
            }
        }

        #endregion Helper Methods

        #region GetBoostTestsCase

        /// <summary>
        /// Tests the proper identification of a testcase
        /// </summary>
        [Test]
        public void CorrectDiscoveryGenericBoostTests()
        {
            using (DummySolution solution = new DummySolution(DefaultSource, "BoostUnitTestSample.cpp"))
            {
                #region excercise

                IList<TestCase> tests = DiscoverTests(solution);

                #endregion excercise

                #region verify

                AssertTestDetails(tests.Last(), QualifiedNameBuilder.FromString("my_test<char>"), solution.SourceFileResourcePaths.First().Path, 33);

                #endregion verify
            }
        }

        /// <summary>
        /// Tests the correct discovery (and correct generation of the fully qualified name)
        /// of tests for when Boost UTF macro BOOST_FIXTURE_TEST_SUITE is utilized
        /// </summary>
        [Test]
        public void CorrectTestsDiscoveryForFIXTURE_TEST_SUITE()
        {
            using (DummySolution solution = new DummySolution(DefaultSource, "BoostFixtureTestSuite.cpp"))
            {
                #region exercise

                /** The BoostFixtureSuiteTest.cpp file consists of 3 test cases: FixtureTest1, FixtureTest2 and BoostTest,
                 * BOOST_FIXTURE_TEST_SUITE -> FixtureSuite1
                 *                             -->BoostTest1
                 *                             -->BoostTest2
                 *                          -> Master Suite
                 *                             -->BoostTest3
                 * BOOST_FIXTURE_TEST_SUITE -> FixtureSuite2
                 *                             -->Fixturetest_case1
                 *                             -->TemplatedTest<int>  (BOOST_AUTO_TEST_CASE_TEMPLATE)
                 *                             -->TemplatedTest<long> (BOOST_AUTO_TEST_CASE_TEMPLATE)
                 *                             -->TemplatedTest<char> (BOOST_AUTO_TEST_CASE_TEMPLATE)
                 */

                IList<TestCase> testList = DiscoverTests(solution);

                #endregion exercise

                #region verification

                AssertTestDetails(testList[0], QualifiedNameBuilder.FromString("FixtureSuite1/BoostTest1"));
                AssertTestDetails(testList[1], QualifiedNameBuilder.FromString("FixtureSuite1/BoostTest2"));
                AssertTestDetails(testList[2], QualifiedNameBuilder.FromString("BoostTest3"));
                AssertTestDetails(testList[3], QualifiedNameBuilder.FromString("FixtureSuite2/Fixturetest_case1"));
                AssertTestDetails(testList[4], QualifiedNameBuilder.FromString("FixtureSuite2/TemplatedTest<int>"));
                AssertTestDetails(testList[5], QualifiedNameBuilder.FromString("FixtureSuite2/TemplatedTest<long>"));
                AssertTestDetails(testList[6], QualifiedNameBuilder.FromString("FixtureSuite2/TemplatedTest<char>"));

                #endregion verification
            }
        }

        /// <summary>
        /// Tests the correct discovery (and correct generation of the fully qualified name)
        /// of tests for when Boost UTF macro BOOST_FIXTURE_TEST_CASE is utilized
        /// </summary>
        [Test]
        public void CorrectTestsDiscoveryForFIXTURE_TEST_CASE()
        {
            using (DummySolution solution = new DummySolution(DefaultSource, "BoostFixtureTestCase.cpp"))
            {
                #region excercise

                /** The BoostFixtureTestCase.cpp file consists of 4 test cases: BoostUnitTest1, Fixturetest_case1, Fixturetest_case1 and Fixturetest_case1,
                 * BOOST_AUTO_TEST_SUITE -> Suit1
                 *                          -->BoostUnitTest1
                 *                          -->Fixturetest_case1
                 *                          -->Fixturetest_case2
                 *                       -> Master Suite
                 *                          -->Fixturetest_case3
                 */

                IList<TestCase> testList = DiscoverTests(solution);

                #endregion excercise

                #region verify

                AssertTestDetails(testList[0], QualifiedNameBuilder.FromString("Suit1/BoostUnitTest1"));
                AssertTestDetails(testList[1], QualifiedNameBuilder.FromString("Suit1/Fixturetest_case1"));
                AssertTestDetails(testList[2], QualifiedNameBuilder.FromString("Suit1/Fixturetest_case2"));
                AssertTestDetails(testList[3], QualifiedNameBuilder.FromString("Fixturetest_case3"));

                #endregion verify
            }
        }

        /// <summary>
        /// Tests the correct discovery (and correct generation of the fully qualified name)
        /// of tests when the Boost UTF macro is spread over multiple lines
        /// </summary>
        [Test]
        public void MultilineBoostMacroDefinitions()
        {
            using (DummySolution solution = new DummySolution(DefaultSource, "BoostMultiLineDefinitions.cpp"))
            {
                IList<TestCase> testList = DiscoverTests(solution);
                
                AssertTestDetails(testList[0], QualifiedNameBuilder.FromString("AutoSuite/TestA"));
                AssertTestDetails(testList[1], QualifiedNameBuilder.FromString("AutoSuite/TestB"));
                AssertTestDetails(testList[2], QualifiedNameBuilder.FromString("AutoSuite/TestC"));
                AssertTestDetails(testList[3], QualifiedNameBuilder.FromString("AutoSuite/FixtureSuite/TestD"));
            }
        }

        /// <summary>
        /// Tests the discovery of BOOST_DATA_TEST_CASE and BOOST_DATA_TEST_CASE_F test cases
        /// </summary>
        [Test]
        public void BOOST_DATA_TEST_CASEDiscovery()
        {
            using (DummySolution solution = new DummySolution(DefaultSource, "BoostDataTestCase.cpp"))
            {
                IList<TestCase> testList = DiscoverTests(solution);

                Assert.That(testList.Count, Is.EqualTo(3));

                AssertTestDetails(testList[0], QualifiedNameBuilder.FromString("data_test_suite/data_1"));
                AssertTestDetails(testList[1], QualifiedNameBuilder.FromString("data_test_suite/data_2"));
                AssertTestDetails(testList[2], QualifiedNameBuilder.FromString("data_3"));
            }
        }

        #endregion GetBoostTestsCase
    }
}