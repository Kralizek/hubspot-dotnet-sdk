﻿using System.Collections.Generic;
using System.Linq;
using AutoFixture.NUnit3;
using HubSpot.Converters;
using NUnit.Framework;

namespace Tests.Converters
{
    [TestFixture]
    public class StringListConverterTests
    {
        [Test, CustomAutoData]
        public void TryConvertTo_returns_true_if_value_is_null(StringListConverter sut)
        {
            var canConvert = sut.TryConvertTo(null, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_is_default_if_value_is_null(StringListConverter sut)
        {
            _ = sut.TryConvertTo(null, out object result);

            Assert.That(result, Is.EqualTo(default));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_returns_true_if_value_is_empty_string(StringListConverter sut)
        {
            var canConvert = sut.TryConvertTo(string.Empty, out _);

            Assert.IsTrue(canConvert);
        }


        [Test, CustomAutoData]
        public void TryConvertTo_result_is_default_if_value_is_empty_string(StringListConverter sut)
        {
            _ = sut.TryConvertTo(string.Empty, out object result);

            Assert.That(result, Is.EqualTo(default));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_returns_true_if_value_is_whitespace(StringListConverter sut)
        {
            var canConvert = sut.TryConvertTo("   ", out _);

            Assert.IsTrue(canConvert);
        }


        [Test, CustomAutoData]
        public void TryConvertTo_result_is_default_if_value_is_whitespace(StringListConverter sut)
        {
            _ = sut.TryConvertTo("  ", out object result);

            Assert.That(result, Is.EqualTo(default));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_returns_true_if_value_is_semicolon_separated_string(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);

            var canConvert = sut.TryConvertTo(value, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_if_value_is_semicolon_separated_string(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);

            _ = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.EquivalentTo(values));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_is_of_type_string_list(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.TypeOf<List<string>>());
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_is_of_type_string_IList(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.True(result is IList<string>);
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_is_of_type_string_IEnumerable(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.True(result is IEnumerable<string>);
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_is_of_type_string_IReadOnlyList(StringListConverter sut, List<string> values)
        {
            var value = string.Join(";", values);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.True(result is IReadOnlyList<string>);
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_without_whitespace_items(StringListConverter sut, List<string> values)
        {
            var valuesWithWhitespace = values.Concat(new[] {" ", "  ", "   "});

            var value = string.Join(";", valuesWithWhitespace);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.EquivalentTo(values));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_array_with_trimmed_items(StringListConverter sut, List<string> values)
        {
            var valuesWithWhitespace = values.Select(s => $"  {s}  ");

            var value = string.Join(";", valuesWithWhitespace);

            var canConvert = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.EquivalentTo(values));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_without_empty_items(StringListConverter sut, List<string> values)
        {
            var valuesWithWhitespace = values.Concat(new[] { string.Empty, "" });

            var value = string.Join(";", valuesWithWhitespace);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.EquivalentTo(values));
        }

        [Test, CustomAutoData]
        public void TryConvertTo_result_list_without_null_items(StringListConverter sut, List<string> values)
        {
            var valuesWithWhitespace = values.Concat(new string[] { null, null });

            var value = string.Join(";", valuesWithWhitespace);
            
            _ = sut.TryConvertTo(value, out object result);

            Assert.That(result, Is.EquivalentTo(values));
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_true_if_value_is_null(StringListConverter sut)
        {
            var canConvert = sut.TryConvertFrom(null, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_null_if_value_is_null(StringListConverter sut)
        {
            
            _ = sut.TryConvertFrom(null, out string result);

            Assert.IsNull(result);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_false_if_value_is_string(StringListConverter sut, string value)
        {
            var canConvert = sut.TryConvertFrom(value, out _);

            Assert.IsFalse(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_null_if_value_is_string(StringListConverter sut, string value)
        {
            
            _ = sut.TryConvertFrom(value, out string result);

            Assert.IsNull(result);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_false_if_value_is_object(StringListConverter sut, object value)
        {
            var canConvert = sut.TryConvertFrom(value, out _);

            Assert.IsFalse(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_null_if_value_is_object(StringListConverter sut, object value)
        {
            _ = sut.TryConvertFrom(value, out string result);

            Assert.IsNull(result);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_true_if_value_is_string_list(StringListConverter sut, List<string> value)
        {
            var canConvert = sut.TryConvertFrom(value, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_true_if_value_is_string_IList(StringListConverter sut, IList<string> value)
        {
            var canConvert = sut.TryConvertFrom(value, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_true_if_value_is_string_IEnumerable(StringListConverter sut, string[] value)
        {
            var iEnumerableValue = value.AsEnumerable();

            var canConvert = sut.TryConvertFrom(iEnumerableValue, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_returns_true_if_value_is_string_IReadOnlyList(StringListConverter sut, string[] value)
        {
            IReadOnlyList<string> iReadOnlyListValue = value;

            var canConvert = sut.TryConvertFrom(iReadOnlyListValue, out _);

            Assert.IsTrue(canConvert);
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_semicolon_separated_string_if_value_is_string_list(StringListConverter sut, List<string> value)
        {
            _ = sut.TryConvertFrom(value, out string result);

            Assert.AreEqual(result, string.Join(";", value));
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_semicolon_separated_string_without_empty_values(StringListConverter sut, List<string> value)
        {
            var valuesWithWhitespace = value.Concat(new[] { string.Empty, "" }).ToList();
            
            _ = sut.TryConvertFrom(valuesWithWhitespace, out string result);

            Assert.AreEqual(result, string.Join(";", value));
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_semicolon_separated_string_without_whitespace_values(StringListConverter sut, List<string> value)
        {
            var valuesWithWhitespace = value.Concat(new[] { "  ", " " }).ToList();
            
            _ = sut.TryConvertFrom(valuesWithWhitespace, out string result);

            Assert.AreEqual(result, string.Join(";", value));
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_semicolon_separated_string_without_null_values(StringListConverter sut, List<string> value)
        {
            var valuesWithWhitespace = value.Concat(new string[] { null, null }).ToList();
            
            _ = sut.TryConvertFrom(valuesWithWhitespace, out string result);

            Assert.AreEqual(result, string.Join(";", value));
        }

        [Test, CustomAutoData]
        public void TryConvertFrom_result_is_semicolon_separated_string_with_trimmed_values(StringListConverter sut, List<string> value)
        {
            var valuesWithWhitespace = value.Select(s => $"  {s}  ").ToList();

            var canConvert = sut.TryConvertFrom(valuesWithWhitespace, out string result);

            Assert.AreEqual(result, string.Join(";", value));
        }
    }
}