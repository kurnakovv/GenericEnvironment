﻿using GenericEnv.UnitTests.EnvVariableConstants;
using System;
using Xunit;

namespace GenericEnv.UnitTests
{
    public class GenericEnvironmentTests : IDisposable
    {
        public GenericEnvironmentTests()
        {
            Environment.SetEnvironmentVariable(NameConstants.String, ValueConstants.String.ToString());
            Environment.SetEnvironmentVariable(NameConstants.Int, ValueConstants.Int.ToString());
            Environment.SetEnvironmentVariable(NameConstants.Bool, ValueConstants.Bool.ToString());
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(NameConstants.String, null);
            Environment.SetEnvironmentVariable(NameConstants.Int, null);
            Environment.SetEnvironmentVariable(NameConstants.Bool, null);
        }

        [Fact(DisplayName = "Can get string variable.")]
        public void GetEnvironmentVariable_CanGetStringVariable_String()
        {
            string result = GenericEnvironment.GetEnvironmentVariable<string>(NameConstants.String);
            Assert.IsType<string>(result);
            Assert.Equal(ValueConstants.String, result);
        }

        [Fact(DisplayName = "Can get int variable.")]
        public void GetEnvironmentVariable_CanGetIntVariable_Int()
        {
            int result = GenericEnvironment.GetEnvironmentVariable<int>(NameConstants.Int);
            Assert.IsType<int>(result);
            Assert.Equal(ValueConstants.Int, result);
        }

        [Fact(DisplayName = "Can get bool variable.")]
        public void GetEnvironmentVariable_CanGetBoolVariable_Bool()
        {
            bool result = GenericEnvironment.GetEnvironmentVariable<bool>(NameConstants.Bool);
            Assert.IsType<bool>(result);
            Assert.Equal(ValueConstants.Bool, result);
        }

        [Fact(DisplayName = "Can get ArgumentNullException when name parameter is null.")]
        public void GetEnvironmentVariable_CanGetArgumentNullExceptionWhenNameParameterIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GenericEnvironment.GetEnvironmentVariable<bool>(null));
        }

        [Fact(DisplayName = "Can get InvalidOperationException when variable not found by name.")]
        public void GetEnvironmentVariable_CanGetInvalidOperationExceptionWhenVariableNotFoundByName_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => GenericEnvironment.GetEnvironmentVariable<bool>("GenericEnvironment_InvalidName"));
        }

        [Fact(DisplayName = "Can get InvalidCastException when type is nullable.")]
        public void GetEnvironmentVariable_CanGetInvalidCastExceptionWhenTypeIsNullable_InvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => GenericEnvironment.GetEnvironmentVariable<bool?>(NameConstants.Bool));
        }

        [Fact(DisplayName = "Can get FormatException when cannot convert variable to type.")]
        public void GetEnvironmentVariable_CanGetFormatExceptionWhenCannotConvertVariableToType_FormatException()
        {
            Assert.Throws<FormatException>(() => GenericEnvironment.GetEnvironmentVariable<bool>(NameConstants.String));
            Assert.Throws<FormatException>(() => GenericEnvironment.GetEnvironmentVariable<bool>(NameConstants.Int));
            Assert.Throws<FormatException>(() => GenericEnvironment.GetEnvironmentVariable<int>(NameConstants.String));
            Assert.Throws<FormatException>(() => GenericEnvironment.GetEnvironmentVariable<int>(NameConstants.Bool));
        }

        [Fact(DisplayName = "Can get envrionment variable if exists.")]
        public void TryGetEnvironmentVariable_CanGetEnvironmentVariableIfExists_TrueAndEnvironmentVariable()
        {
            bool result = GenericEnvironment.TryGetEnvironmentVariable(NameConstants.Int, out int value);
            Assert.True(result);
            Assert.IsType<int>(value);
            Assert.Equal(ValueConstants.Int, value);
        }

        [Fact(DisplayName = "Can get environment when TType is nullable.")]
        public void TryGetEnvironmentVariable_CanGetEnvironmentWhenTTypeIsNullable_TrueAndEnvironment()
        {
            bool result = GenericEnvironment.TryGetEnvironmentVariable(NameConstants.Int, out int? value);
            Assert.True(result);
            Assert.Equal(ValueConstants.Int, value);
        }

        [Fact(DisplayName = "Cannot get environment variable if name is null.")]
        public void TryGetEnvironmentVariable_CannotGetEnvironmentVariableIfNameIsNull_FalseAndDefaultValueType()
        {
            bool result = GenericEnvironment.TryGetEnvironmentVariable(null, out int value);
            Assert.False(result);
            Assert.Equal(default(int), value);
        }

        [Fact(DisplayName = "Cannot get environment variable when it not found by name.")]
        public void TryGetEnvironmentVariable_CannotGetEnvironmentVariableWhenItNotFoundByName_FalseAndDefaultValueType()
        {
            bool result = GenericEnvironment.TryGetEnvironmentVariable("GenericEnvironment_InvalidName", out int value);
            Assert.False(result);
            Assert.Equal(default(int), value);
        }

        [Fact(DisplayName = "Cannot get environment variable when it not found by name for nullable type.")]
        public void TryGetEnvironmentVariable_CannotGetEnvironmentVariableWhenItNotFoundByNameForNullableType_FalseAndDefaultValueType()
        {
            bool result = GenericEnvironment.TryGetEnvironmentVariable("GenericEnvironment_InvalidName", out int? value);
            Assert.False(result);
            Assert.Equal(default(int?), value);
        }

        [Fact(DisplayName = "Can get environment variable if exists.")]
        public void GetEnvironmentVariableOrDefault_CanGetEnvironmentVariableIfExists_Int()
        {
            int result = GenericEnvironment.GetEnvironmentVariableOrDefault<int>(NameConstants.Int);
            Assert.Equal(ValueConstants.Int, result);
        }

        [Fact(DisplayName = "Cannot get environment variable when it not found by name.")]
        public void GetEnvironmentVariableOrDefault_CannotGetEnvironmentVariableWhenItNotFoundByName_Default()
        {
            int? result = GenericEnvironment.GetEnvironmentVariableOrDefault<int?>("GenericEnvironment_InvalidName");
            Assert.Null(result);
        }
    }
}
