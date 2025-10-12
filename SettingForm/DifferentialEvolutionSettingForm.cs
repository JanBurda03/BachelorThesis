public class DifferentialEvolutionSettingForm : AlgorithmSettingForm
{

    private NumericUpDown tournamentSizeNumeric;
    private NumericUpDown averageElementsChangedNumeric;
    private NumericUpDown hardStopNumeric;

    private Button okButton;
    private Button cancelButton;

    public DifferentialEvolutionSettingForm():base()
    {   
    }

    protected override void InitializeComponents()
    {
        int labelWidth = 180;
        int top = 10;
        int spacing = 30;

        // tournament size
        AddLabel("Tournament Size:", 10, top, labelWidth);
        tournamentSizeNumeric = new NumericUpDown
        {
            Left = 200,
            Top = top,
            Width = 100,
            Minimum = 1,
            Value = 2,
        };
        Controls.Add(tournamentSizeNumeric);
        top += spacing;

        // hard stop
        AddLabel("Hard Stop:", 10, top, labelWidth);
        hardStopNumeric = new NumericUpDown
        {
            Left = 200,
            Top = top,
            Width = 100,
            Minimum = 0,
            Value = 0,
        };
        Controls.Add(hardStopNumeric);
        top += spacing;

        AddLabel("Avg. El. Changed:", 10, top, labelWidth);
        averageElementsChangedNumeric = new NumericUpDown
        {
            Left = 200,
            Top = top,
            Width = 100,
            DecimalPlaces = 2,
            Increment = 0.1M,
            Minimum = 0,
            Maximum = 1000, 
            Value = 1.5M
        };
        Controls.Add(averageElementsChangedNumeric);
        top += spacing;

        // OK Button
        okButton = new Button
        {
            Text = "OK",
            Left = 50,
            Top = top,
            Width = 100
        };
        okButton.Click += OkButton_Click;
        Controls.Add(okButton);

        // Cancel Button
        cancelButton = new Button
        {
            Text = "Cancel",
            Left = 160,
            Top = top,
            Width = 100
        };
        cancelButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.Add(cancelButton);
    }

    private void OkButton_Click(object sender, EventArgs e)
    {

        int hardStop = (int)hardStopNumeric.Value;
        int tournamentSize = (int)tournamentSizeNumeric.Value;
        double averageElementsChanged = (double)averageElementsChangedNumeric.Value;

        EvolutionaryAlgorithmSetting = new DifferentialEvolutionAlgorithmSetting(hardStop, ContainersFitnessEvaluator.Minimizing, tournamentSize, averageElementsChanged);


        DialogResult = DialogResult.OK;
        Close();
    }








}

