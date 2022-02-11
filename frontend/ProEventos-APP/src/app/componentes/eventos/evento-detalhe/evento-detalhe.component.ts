import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  form!: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = new FormGroup(
      {
        tema: new FormControl('',
          [Validators.required, Validators.minLength(5), Validators.maxLength(50)]),
        local: new FormControl('', [Validators.required]),
        dataEvento: new FormControl('', [Validators.required]),
        qtdPessoas: new FormControl('',
          [Validators.required, Validators.max(1000)]),
        telefone: new FormControl('', Validators.required),
        email: new FormControl('',
          [Validators.required, Validators.email]),
        imgUrl: new FormControl('', Validators.required),
      }
    );
  }

  public validarFormulario(): void{

  }
}
