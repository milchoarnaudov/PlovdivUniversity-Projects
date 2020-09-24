package com.example.mydietmate;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class CaloriesCalculatorActivity extends AppCompatActivity {
    EditText weightInput;
    EditText heightInput;
    EditText ageInput;
    TextView bmr;
    TextView loseWeight;
    TextView gainWeight;
    Button btnCalc;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.setContentView(R.layout.activity_calories_calculator);
        this.weightInput = this.findViewById(R.id.weight_input);
        this.heightInput = this.findViewById(R.id.height_input);
        this.ageInput = this.findViewById(R.id.age_input);
        this.btnCalc = this.findViewById(R.id.calc_btn);
        this.bmr = this.findViewById(R.id.bmr_output);
        this.loseWeight = this.findViewById(R.id.lose_weight_output);
        this.gainWeight = this.findViewById(R.id.gain_weight_output);

        btnCalc.setOnClickListener((view) -> {
            double bmr = CalculateBMR();
            this.bmr.setText(getResources().getString(R.string.basal_metabolic_rate) + String.valueOf(bmr));
            this.loseWeight.setText(getResources().getString(R.string.calories_to_lose_weight) + String.valueOf(bmr - 200));
            this.gainWeight.setText(getResources().getString(R.string.calories_to_gain_weight) + String.valueOf(bmr + 200));
        });
    }

    protected double CalculateBMR(){
        int weight = Integer.parseInt(this.weightInput.getText().toString());
        int height = Integer.parseInt(this.heightInput.getText().toString());
        int age = Integer.parseInt(this.ageInput.getText().toString());

        return (10 * weight) + (6.25 * height) + (5 * age) + 5;
    }
}