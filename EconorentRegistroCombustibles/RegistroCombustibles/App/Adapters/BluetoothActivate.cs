using Android.Bluetooth;

namespace RegistroCombustibles.Utilitarios
{
    /// <summary>
    /// Bluetooth activate.
    /// </summary>
    public class BluetoothActivate
    {
        /// <summary>
        /// Ises the connected.
        /// </summary>
        /// <returns><c>true</c>, if connected was ised, <c>false</c> otherwise.</returns>
        public static bool IsConnected()
        {
            bool conectado = false;
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter.IsEnabled)
                conectado = true;
            else
                conectado = false;

            return conectado;
        }

        /// <summary>
        /// Disconnected this instance.
        /// </summary>
        public static void Disconnected()
        {
            if (BluetoothActivate.IsConnected())
            {
                BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
                mBluetoothAdapter.Disable();
            }
        }

        /// <summary>
        /// Activated this instance.
        /// </summary>
        public static void Activated()
        {
            if (!BluetoothActivate.IsConnected())
            {
                BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
                mBluetoothAdapter.Enable();
            }
        }
    }
}