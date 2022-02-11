import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  form!: FormGroup;

  get fb(): any{
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.referenciarFormulario();
  }

  public referenciarFormulario(): void{
    this.form = this.formBuilder.group(
      {
        tema: new FormControl('', [Validators.required,
                                    Validators.minLength(5),
                                    Validators.maxLength(50)]),
        local: ['', [Validators.required]],
        dataEvento: ['', [Validators.required]],
        qtdPessoas: ['', [Validators.required, Validators.max(1000)]],
        telefone: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        imgUrl: ['', Validators.required],
      }
    );
  }

  public resetarForm(): void {
    this.form.reset();
  }
}
