namespace PDFSplit.ProgramSettings {
    /// <summary>
    /// <see cref="QuantityUnit"/> represents the different units which this software can messure and split after.
    /// </summary>
    public enum QuantityUnit {
        MB,
        MiB,
        Pages,
    }

    public static class QuantityUnitMethods {


        public static string ToString(this QuantityUnit qUnit) {
            switch (qUnit) {
                case QuantityUnit.MB:
                    return Properties.strings.MB;
                case QuantityUnit.MiB:
                    return Properties.strings.MiB;
                case QuantityUnit.Pages:
                    return Properties.strings.Pages;
            }
            return "";
        }
    }
}
