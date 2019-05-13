using Android.App;
using Android.Text;
using Android.Widget;
using Java.Lang;

namespace RegistroCombustibles.Utilitarios
{
    /// <summary>
    /// Mascaras text watcher.
    /// </summary>
    public class MascarasTextWatcher : Java.Lang.Object, ITextWatcher
    {
        EditText editText;
        Activity activity;
        string textoFormateado;
        public static int TIPO_ENTERO  = 1;
        public static int TIPO_DECIMAL = 2;
        int tipoFormateador;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RegistroCombustibles.Utilitarios.MascarasTextWatcher"/> class.
        /// </summary>
        /// <param name="editText">Edit text.</param>
        /// <param name="activity">Activity.</param>
        public MascarasTextWatcher(EditText editText, Activity activity, int tipoFormateador)
        {
            this.activity = activity;
            this.editText = editText;
            this.tipoFormateador = tipoFormateador;
        }

        /// <summary>
        /// Afters the text changed.
        /// </summary>
        /// <param name="s">S.</param>
        public void AfterTextChanged(IEditable s){}

        /// <summary>
        /// Befores the text changed.
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="start">Start.</param>
        /// <param name="count">Count.</param>
        /// <param name="after">After.</param>
        public void BeforeTextChanged(ICharSequence s, int start, int count, int after){}

        /// <summary>
        /// Ons the text changed.
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="start">Start.</param>
        /// <param name="before">Before.</param>
        /// <param name="count">Count.</param>
        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (tipoFormateador == TIPO_ENTERO)
            {
                textoFormateado = MascarasEditText.formatearMonto(editText.Text);
                editText.RemoveTextChangedListener(this);
                editText.Text = textoFormateado;
                editText.AddTextChangedListener(this);
                editText.SetSelection(editText.Text.Length);
                editText.SetCursorVisible(true);
            }else if (tipoFormateador == TIPO_DECIMAL)
            {
                textoFormateado = MascarasEditText.FormatearDecimal(editText.Text);
                editText.RemoveTextChangedListener(this);
                editText.Text = textoFormateado;
                editText.AddTextChangedListener(this);
                editText.SetSelection(editText.Text.Length);
                editText.SetCursorVisible(true);
            }
        }
    }
}