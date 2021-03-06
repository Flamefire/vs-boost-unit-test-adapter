// (C) Copyright ETAS 2015.
// Distributed under the Boost Software License, Version 1.0.
// (See accompanying file LICENSE_1_0.txt or copy at
// http://www.boost.org/LICENSE_1_0.txt)

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "BoostTestAdapter.SourceFilter.ConditionalInclusions")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "BoostTestAdapter.Utility.VisualStudio")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "BoostTestAdapter.Settings")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "BoostTestAdapter.Boost.Results.LogEntryTypes.LogEntryException")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.BoostTestDiscoverer.#DiscoverTests(System.Collections.Generic.IEnumerable`1<System.String>,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IDiscoveryContext,Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging.IMessageLogger,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.ITestCaseDiscoverySink)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.BoostTestExecutor.#RunTests(System.Collections.Generic.IEnumerable`1<System.String>,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IRunContext,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IFrameworkHandle)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.BoostTestExecutor.#RunBoostTests(System.Collections.Generic.IEnumerable`1<BoostTestAdapter.Utility.TestRun>,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IRunContext,Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IFrameworkHandle)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.SourceFilter.ConditionalInclusions.ConditionalInclusionsMachine.#Apply(BoostTestAdapter.SourceFilter.CppSourceFile,VisualStudioAdapter.Defines)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.Boost.Runner.BoostTestRunnerBase.#KillProcess(System.Diagnostics.Process,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "BoostTestAdapter.SourceFilter.ExpressionEvaluation.#EvaluateExpression(System.String,VisualStudioAdapter.Defines)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XML", Scope = "type", Target = "BoostTestAdapter.Boost.Results.BoostTestResultXMLOutput")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "BoostTestAdapter.Boost.Results.BoostTestResultOutputBase.#.ctor(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Std", Scope = "member", Target = "BoostTestAdapter.Settings.BoostTestAdapterSettings.#EnableStdOutRedirection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Std", Scope = "member", Target = "BoostTestAdapter.Settings.BoostTestAdapterSettings.#EnableStdErrRedirection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Scope = "member", Target = "BoostTestAdapter.Settings.TestSourceFilter.#Empty")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "BoostTestAdapter.Settings.TestSourceFilter.#Include")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "BoostTestAdapter.Settings.TestSourceFilter.#Include")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "BoostTestAdapter.Settings.TestSourceFilter.#Exclude")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "BoostTestAdapter.Settings.TestSourceFilter.#Exclude")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DOT", Scope = "member", Target = "BoostTestAdapter.Boost.Runner.ListContentFormat.#DOT")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HRF", Scope = "member", Target = "BoostTestAdapter.Boost.Runner.ListContentFormat.#HRF")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser+BoostTestFrameworkVisitor.#VisitNode_stmt(Antlr.DOT.DOTParser+Node_stmtContext)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser+BoostTestFrameworkVisitor.#VisitEdge_stmt(Antlr.DOT.DOTParser+Edge_stmtContext)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DOT", Scope = "type", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Deserialiser", Scope = "type", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "BoostTestAdapter.Discoverers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "BoostTestAdapter.Utility.TestPathGenerator.#Generate(System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "BoostTestAdapter.Utility.TestPathGenerator.#GenerateFileName(System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Deserialise", Scope = "member", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser.#Deserialise(System.IO.Stream)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Deserialise", Scope = "member", Target = "BoostTestAdapter.Boost.Test.TestFrameworkDOTDeserialiser.#Deserialise(System.IO.Stream,BoostTestAdapter.Boost.Test.ITestVisitor)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope = "type", Target = "BoostTestAdapter.Utility.BoostTestRunnerCommandLineArgsEx")]

