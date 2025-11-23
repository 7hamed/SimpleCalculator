using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.DesignUI;
using Krypton.Toolkit;
using System.Windows.Forms;
using Calculator.Logic;
using Calculator.DesginUI;

namespace Calculator
{
    public partial class frmCalculator : frmMainFormat
    {
        private IExpressionCalculator _CalculatorEngine = new clsExpressionCalculator();
        private double _PrevResult;
        private bool _ShouldResetScreen;

        public frmCalculator()
        {
            InitializeComponent();

            this._SetFormPositionCenterScreen();            
        }

        private void _CancelSelection()
        {
            this.ActiveControl = lblResult;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (_ShouldResetScreen)
            {
                lblResult.Text = string.Empty;
                _ShouldResetScreen = false;
            }
            lblEquasion.Text = string.Empty;
            
            lblResult.Text += ((KryptonButton)sender).Tag;

            _CancelSelection();
        }

        private bool _isOperandDecimal(string operandText)
        {
            for (int i = operandText.Length - 1; i >= 0; i--)
            {
                if (operandText[i] == ' ')
                    return false;
                else if (operandText[i] == '.')
                    return true;
            }

            return false;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (_ShouldResetScreen)
            {
                _ShouldResetScreen = false;
            }
            lblEquasion.Text = string.Empty;

            if (!_isOperandDecimal(lblResult.Text))
                lblResult.Text += ((Krypton.Toolkit.KryptonButton)sender).Tag;

            _CancelSelection();
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            if (_ShouldResetScreen)
            {
                _ShouldResetScreen = false;
            }
            lblEquasion.Text = string.Empty;

            if (lblResult.Text.LastOrDefault() == ' ')
                btnDelete.PerformClick();

            lblResult.Text += " " + ((Krypton.Toolkit.KryptonButton)sender).Tag + " ";

            _CancelSelection();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            lblEquasion.Text = lblResult.Text + " =";
            _ShouldResetScreen = true;

            if (_CalculatorEngine.TryEvaluate(lblResult.Text, out double Result))
            {
                lblResult.Text = Result.ToString();
                _PrevResult = Result;
            }
            else
            {
                lblResult.Text = "Error Expression Format";
                lblEquasion.Text = string.Empty;
                _PrevResult = 0;
            }

            _CancelSelection();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            btnClear_Click(null, null);

            _PrevResult = 0;
            _ShouldResetScreen = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            lblEquasion.Text = string.Empty;
            _PrevResult = 0;
            _ShouldResetScreen = true;

            _CancelSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _ShouldResetScreen = false;

            if (lblResult.Text.Length > 0)
            {
                if (lblResult.Text.LastOrDefault() == ' ')
                    lblResult.Text = lblResult.Text.Remove(lblResult.Text.Length - 3, 3);
                else
                    lblResult.Text = lblResult.Text.Remove(lblResult.Text.Length - 1, 1);
            }

            _CancelSelection();
        }

        private bool _isOperandNegative(string operandText)
        {
            for (int i = operandText.Length - 1; i >= 0; i--)
            {
                if (operandText[i] == ' ')
                    return false;
                else if (operandText[i] == '-')
                    return true;
            }

            return false;
        }

        private void btnPositiveNegative_Click(object sender, EventArgs e)
        {
            if (_ShouldResetScreen)
            {
                lblResult.Text = string.Empty;
                _ShouldResetScreen = false;
            }
            lblEquasion.Text = string.Empty;

            if (_isOperandNegative(lblResult.Text))
            {
                if (lblResult.Text.LastOrDefault() == '-')
                    lblResult.Text = lblResult.Text.Remove(lblResult.Text.Length - 1, 1);
            }
            else
                lblResult.Text += "-";

            _CancelSelection();
        }

        private void _ButtonNumberDownAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnNumberColorPressed;
            btn.StateCommon.Back.Color2 = clsGlobal.btnNumberColorPressed;

            btn.StateCommon.Border.Color1 = clsGlobal.btnNumberColorPressed;
            btn.StateCommon.Border.Color2 = clsGlobal.btnNumberColorPressed;

            btn.PerformClick();
        }
        private void _ButtonNumberUpAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnNumberColorNormal;
            btn.StateCommon.Back.Color2 = clsGlobal.btnNumberColorNormal;

            btn.StateCommon.Border.Color1 = clsGlobal.btnNumberColorNormal;
            btn.StateCommon.Border.Color2 = clsGlobal.btnNumberColorNormal;
        }

        private void _ButtonOperationDownAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnOperationColorPressed;
            btn.StateCommon.Back.Color2 = clsGlobal.btnOperationColorPressed;

            btn.StateCommon.Border.Color1 = clsGlobal.btnOperationColorPressed;
            btn.StateCommon.Border.Color2 = clsGlobal.btnOperationColorPressed;

            btn.PerformClick();
        }
        private void _ButtonOperationUpAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnOperationColorNormal;
            btn.StateCommon.Back.Color2 = clsGlobal.btnOperationColorNormal;

            btn.StateCommon.Border.Color1 = clsGlobal.btnOperationColorNormal;
            btn.StateCommon.Border.Color2 = clsGlobal.btnOperationColorNormal;
        }

        private void _ButtonFunctionDownAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnFunctionColorPressed;
            btn.StateCommon.Back.Color2 = clsGlobal.btnFunctionColorPressed;

            btn.StateCommon.Border.Color1 = clsGlobal.btnFunctionColorPressed;
            btn.StateCommon.Border.Color2 = clsGlobal.btnFunctionColorPressed;

            btn.PerformClick();
        }
        private void _ButtonFunctionUpAnimated(KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = clsGlobal.btnFunctionColorNormal;
            btn.StateCommon.Back.Color2 = clsGlobal.btnFunctionColorNormal;

            btn.StateCommon.Border.Color1 = clsGlobal.btnFunctionColorNormal;
            btn.StateCommon.Border.Color2 = clsGlobal.btnFunctionColorNormal;
        }


        private void frmCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // --- Numbers (Main Keyboard & Numpad) ---
                case Keys.D1:
                case Keys.NumPad1:
                    _ButtonNumberDownAnimated(btn1);
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    _ButtonNumberDownAnimated(btn2);
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    _ButtonNumberDownAnimated(btn3);
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    _ButtonNumberDownAnimated(btn4);
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    _ButtonNumberDownAnimated(btn5);
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    _ButtonNumberDownAnimated(btn6);
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    _ButtonNumberDownAnimated(btn7);
                    break;

                // Special Case: 8 and * share the same key
                case Keys.D8:
                    if (e.Shift)
                        _ButtonOperationDownAnimated(btnMultiplication);
                    else
                        _ButtonNumberDownAnimated(btn8);
                    break;
                case Keys.NumPad8:
                    _ButtonNumberDownAnimated(btn8);
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    _ButtonNumberDownAnimated(btn9);
                    break;

                case Keys.D0:
                case Keys.NumPad0:
                    _ButtonNumberDownAnimated(btn0);
                    break;

                case Keys.OemPeriod:
                    if (e.Shift)
                        _ButtonNumberDownAnimated(btnDecimal);
                    break;

                // --- Operations ---
                case Keys.Oemplus:
                    if (e.Shift)
                        _ButtonOperationDownAnimated(btnAddition);
                    else
                        _ButtonOperationDownAnimated(btnEquals);
                    break;
                case Keys.Add:
                    _ButtonOperationDownAnimated(btnAddition);
                    break;

                case Keys.Subtract:     // Numpad -
                case Keys.OemMinus:     // Main - (next to 0)
                    _ButtonOperationDownAnimated(btnSubtraction);
                    break;

                case Keys.Multiply:     // Numpad *
                    _ButtonOperationDownAnimated(btnMultiplication);
                    break;

                case Keys.Divide:       // Numpad /
                case Keys.OemQuestion:  // Main / (next to Shift)
                    _ButtonOperationDownAnimated(btnDivision);
                    break;

                case Keys.Enter:
                    _ButtonOperationDownAnimated(btnEquals);
                    break;

                // --- Special Keys ---

                // There is no physical key for "+/-", so we use F9 (Windows Standard)
                // or the letter 'N' (for Negative)
                case Keys.F9:
                case Keys.N:
                    _ButtonFunctionDownAnimated(btnPositiveNegative);
                    break;

                // Backspace to remove last digit
                case Keys.Back:
                    _ButtonFunctionDownAnimated(btnDelete);
                    break;

                case Keys.Escape:
                case Keys.C:
                    _ButtonFunctionDownAnimated(btnClear);
                    break;
            }
        }

        private void frmCalculator_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // --- Numbers (Main Keyboard & Numpad) ---
                case Keys.D1:
                case Keys.NumPad1:
                    _ButtonNumberUpAnimated(btn1);
                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    _ButtonNumberUpAnimated(btn2);
                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    _ButtonNumberUpAnimated(btn3);
                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    _ButtonNumberUpAnimated(btn4);
                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    _ButtonNumberUpAnimated(btn5);
                    break;

                case Keys.D6:
                case Keys.NumPad6:
                    _ButtonNumberUpAnimated(btn6);
                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    _ButtonNumberUpAnimated(btn7);
                    break;

                // Special Case: 8 and * share the same key
                case Keys.D8:
                    if (e.Shift)
                        _ButtonOperationUpAnimated(btnMultiplication);
                    else
                        _ButtonNumberUpAnimated(btn8);
                    break;
                case Keys.NumPad8:
                    _ButtonNumberUpAnimated(btn8);
                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    _ButtonNumberUpAnimated(btn9);
                    break;

                case Keys.D0:
                case Keys.NumPad0:
                    _ButtonNumberUpAnimated(btn0);
                    break;

                case Keys.OemPeriod:
                    if (e.Shift)
                        _ButtonNumberUpAnimated(btnDecimal);
                    break;

                // --- Operations ---
                case Keys.Oemplus:
                    if (e.Shift)
                        _ButtonOperationUpAnimated(btnAddition);
                    else
                        _ButtonOperationUpAnimated(btnEquals);
                    break;
                case Keys.Add:
                    _ButtonOperationUpAnimated(btnAddition);
                    break;

                case Keys.Subtract:     // Numpad -
                case Keys.OemMinus:     // Main - (next to 0)
                    _ButtonOperationUpAnimated(btnSubtraction);
                    break;

                case Keys.Multiply:     // Numpad *
                    _ButtonOperationUpAnimated(btnMultiplication);
                    break;

                case Keys.Divide:       // Numpad /
                case Keys.OemQuestion:  // Main / (next to Shift)
                    _ButtonOperationUpAnimated(btnDivision);
                    break;

                case Keys.Enter:
                    _ButtonOperationUpAnimated(btnEquals);
                    break;

                // --- Special Keys ---

                // There is no physical key for "+/-", so we use F9 (Windows Standard)
                // or the letter 'N' (for Negative)
                case Keys.F9:
                case Keys.N:
                    _ButtonFunctionUpAnimated(btnPositiveNegative);
                    break;

                // Backspace to remove last digit
                case Keys.Back:
                    _ButtonFunctionUpAnimated(btnDelete);
                    break;

                case Keys.Escape:
                case Keys.C:
                    _ButtonFunctionUpAnimated(btnClear);
                    break;
            }
        }

        
    }
}
