import { AbstractControl, AbstractControlOptions } from '@angular/forms';
import { CustomValidators } from '../../../helpers/Validators/CustomValidators';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  get fb(): any { return this.form.controls; }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.inicializarForm();
  }

  private inicializarForm(): void {

    const formOptions: AbstractControlOptions = {
      validators: CustomValidators.MustMatch('senha', 'confirmarSenha')
    };

    this.form = this.formBuilder.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['',
        [Validators.required, Validators.email]
      ],
      usuario: ['', [Validators.required, Validators.minLength(6)]],
      senha: ['',
        [Validators.required, Validators.minLength(6)]
      ],
      confirmarSenha: ['', Validators.required],
    }, formOptions);
  }
}
