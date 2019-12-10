using System;

namespace PDFSplit {
    /// <summary>
    /// Thrown when a file was selected that isn't a pdf-file.
    /// </summary>
    [Serializable]
    class NoPdfException : Exception{
        public NoPdfException() {
        }
    }
}
