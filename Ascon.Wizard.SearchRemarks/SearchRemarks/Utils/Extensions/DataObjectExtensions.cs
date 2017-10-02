using Ascon.Pilot.SDK;
using SearchRemarks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchRemarks.Utils.Extensions
{
    public static class DataObjectExtensions
    {
        public static PilotObject MapToProjectObject(this IDataObject source)
        {
            if (source == null)
                return null;

            return new PilotObject
            {
                Id = source.Id,
                Name = source.DisplayName,
                ParentId = source.ParentId,
                Type = source.Type.MapToType(),
                Attributes = source.Attributes,
                Files = source.Files.ToList(),
                Access = source.Access2.ToList(),
                Children = source.Children.ToList(),
                UserId = source.Creator.Id,
                DataCreate = source.Created
            };
        }

        public static Types MapToType(this IType source)
        {
            if (source == null)
                return null;

            return new Types
            {
                Id = source.Id,
                Attributes = source.Attributes,
                Children = source.Children,
                DisplayAttributes = source.DisplayAttributes,
                HasFiles = source.HasFiles,
                IsDeleted = source.IsDeleted,
                IsMountable = source.IsMountable,
                IsProject = source.IsProject,
                IsService = source.IsService,
                Kind = source.Kind,
                Name = source.Name,
                Sort = source.Sort,
                SvgIcon = source.SvgIcon,
                Title = source.Title
            };
        }
    }
}
