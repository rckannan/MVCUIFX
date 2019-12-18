using NHibernate;
using NHibernate.Criterion;
using RithV.FX.EntityDTO;
using System;
using System.Collections.Generic;

namespace RithV.FX.WebAPI.Infra.Base
{
    public static class FilterCriteria
    {
        public static void GenerateFilters(IEnumerable<GenericFilter> filters, ref ICriteria criteria)
        {
            var disjunction = Restrictions.Disjunction();
            var conjunction = Restrictions.Conjunction();


            foreach (var itm in filters)
            {
                switch (itm.Condition)
                {
                    case Conditions.And:
                        conjunction.Add(GetRestrictions(itm));
                        criteria.Add(conjunction);
                        break;
                    case Conditions.Or:
                        disjunction.Add(GetRestrictions(itm));
                        criteria.Add(disjunction);
                        break;
                    case Conditions.Between:
                        conjunction.Add(Restrictions.Between(itm.ColumnName, Convert.ToDateTime(itm.ColumnData), Convert.ToDateTime(itm.ColumnData2)));
                        break;
                    case Conditions.Lessthan:
                        conjunction.Add(GetRestrictions_LessThan(itm));
                        break;
                    case Conditions.Greaterthan:
                        conjunction.Add(GetRestrictions_GreaterThan(itm));
                        break;
                    case Conditions.Like:
                        conjunction.Add(Restrictions.Like(itm.ColumnName, (String)itm.ColumnData));
                        break;
                    default:
                        conjunction.Add(GetRestrictions(itm));
                        break;
                }
            }
        }

        private static dynamic GetRestrictions(GenericFilter filter)
        {

            if ((Type)filter.ColumnType == typeof(System.Int16))
            {
                return Restrictions.Eq(filter.ColumnName, (Int16)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int32))
            {
                return Restrictions.Eq(filter.ColumnName, (Int32)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int64))
            {
                return Restrictions.Eq(filter.ColumnName, (Int64)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Decimal))
            {
                return Restrictions.Eq(filter.ColumnName, (Decimal)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Double))
            {
                return Restrictions.Eq(filter.ColumnName, (Double)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Boolean))
            {
                return Restrictions.Eq(filter.ColumnName, (Boolean)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.String))
            {
                return Restrictions.Eq(filter.ColumnName, (String)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.DateTime))
            {
                return Restrictions.Eq(filter.ColumnName, Convert.ToDateTime(filter.ColumnData));
            }
            else if ((Type)filter.ColumnType == typeof(System.Char))
            {
                return Restrictions.Eq(filter.ColumnName, (Char)filter.ColumnData);
            }
            else
            {
                return Restrictions.Eq(filter.ColumnName, filter.ColumnData);
            }
        }

        private static dynamic GetRestrictions_LessThan(GenericFilter filter)
        {

            if ((Type)filter.ColumnType == typeof(System.Int16))
            {
                return Restrictions.Le(filter.ColumnName, (Int16)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int32))
            {
                return Restrictions.Le(filter.ColumnName, (Int32)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int64))
            {
                return Restrictions.Le(filter.ColumnName, (Int64)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Decimal))
            {
                return Restrictions.Le(filter.ColumnName, (Decimal)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Double))
            {
                return Restrictions.Le(filter.ColumnName, (Double)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Boolean))
            {
                return Restrictions.Le(filter.ColumnName, (Boolean)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.String))
            {
                return Restrictions.Le(filter.ColumnName, (String)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.DateTime))
            {
                return Restrictions.Le(filter.ColumnName, Convert.ToDateTime(filter.ColumnData));
            }
            else if ((Type)filter.ColumnType == typeof(System.Char))
            {
                return Restrictions.Le(filter.ColumnName, (Char)filter.ColumnData);
            }
            else
            {
                return Restrictions.Le(filter.ColumnName, filter.ColumnData);
            }
        }

        private static dynamic GetRestrictions_GreaterThan(GenericFilter filter)
        {

            if ((Type)filter.ColumnType == typeof(System.Int16))
            {
                return Restrictions.Ge(filter.ColumnName, (Int16)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int32))
            {
                return Restrictions.Ge(filter.ColumnName, (Int32)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Int64))
            {
                return Restrictions.Ge(filter.ColumnName, (Int64)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Decimal))
            {
                return Restrictions.Ge(filter.ColumnName, (Decimal)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Double))
            {
                return Restrictions.Ge(filter.ColumnName, (Double)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.Boolean))
            {
                return Restrictions.Ge(filter.ColumnName, (Boolean)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.String))
            {
                return Restrictions.Ge(filter.ColumnName, (String)filter.ColumnData);
            }
            else if ((Type)filter.ColumnType == typeof(System.DateTime))
            {
                return Restrictions.Ge(filter.ColumnName, Convert.ToDateTime(filter.ColumnData));
            }
            else if ((Type)filter.ColumnType == typeof(System.Char))
            {
                return Restrictions.Ge(filter.ColumnName, (Char)filter.ColumnData);
            }
            else
            {
                return Restrictions.Ge(filter.ColumnName, filter.ColumnData);
            }
        }


    }
}