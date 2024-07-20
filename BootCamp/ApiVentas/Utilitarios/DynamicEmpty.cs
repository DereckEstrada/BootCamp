namespace ApiVentas.Utilitarios
{
    public class DynamicEmpty
    {
        public bool IsEmpty(dynamic obj)
        {
            if (obj is IEnumerable<dynamic> list)
            {
                return !list.Any();
            }
            else if (obj == null)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}
