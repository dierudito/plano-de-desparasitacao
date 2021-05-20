using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DM.Desparasitacao.CrossCutting.Filters.Helpers
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> GetDataSource<T>() where T : struct
        {
            Type enumType = typeof(T);
            Type type = Nullable.GetUnderlyingType(enumType);
            if ((object)type == null)
                type = enumType;
            enumType = type;
            if (!enumType.IsEnum)
                throw new ArgumentException("Type must be a enum");
            return Enum.GetValues(enumType).OfType<T>().ToDictionary<T, int, string>((Func<T, int>)(enumValue => EnumHelper.GetValue<T>(enumValue)), (Func<T, string>)(enumValue => EnumHelper.GetDescription(enumType, (object)enumValue)));
        }

        public static async Task<Dictionary<int, string>> GetDataSourceAsync<T>() where T : struct => await Task.Run<Dictionary<int, string>>((Func<Dictionary<int, string>>)(() => EnumHelper.GetDataSource<T>()));

        public static int? GetValue<TEnum>(TEnum? enumValue) where TEnum : struct => !enumValue.HasValue ? new int?() : new int?(EnumHelper.GetValue<TEnum>(enumValue.Value));

        public static int GetValue<TEnum>(TEnum enumValue) => (int)Convert.ChangeType((object)enumValue, typeof(int));

        public static string GetDescription<TEnum>(TEnum enumValue) where TEnum : struct => EnumHelper.GetDescription(typeof(TEnum), (object)enumValue);

        public static string GetDescription<TEnum>(TEnum? enumValue) where TEnum : struct => !enumValue.HasValue ? (string)null : EnumHelper.GetDescription(typeof(TEnum), (object)enumValue.Value);

        public static string GetDescription(Type enumType, object enumValue)
        {
            string name = Enum.GetName(enumType, enumValue);
            MemberInfo element = ((IEnumerable<MemberInfo>)enumType.GetMember(name)).FirstOrDefault<MemberInfo>();
            if (element != (MemberInfo)null)
                name = element.GetCustomAttribute<DisplayAttribute>()?.Name ?? element.GetCustomAttribute<DescriptionAttribute>()?.Description ?? name;
            return name;
        }

        public static TOuput ConvertEnum<TInput, TOuput>(TInput input)
          where TInput : struct
          where TOuput : struct
        {
            TOuput output;
            EnumHelper.TryConvertEnum<TInput, TOuput>(input, out output);
            return output;
        }

        public static bool TryConvertEnum<TInput, TOuput>(TInput input, out TOuput output)
          where TInput : struct
          where TOuput : struct
        {
            if (Enum.IsDefined(typeof(TInput), (object)input))
                return Enum.TryParse<TOuput>(input.ToString(), out output);
            output = default(TOuput);
            return false;
        }
    }
}
