import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../services/Produto.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Produto } from '../../models/Produto';

@Component({
  selector: 'app-Produto',
  templateUrl: './Produto.component.html',
  styleUrls: ['./Produto.component.css'],
  standalone: false,
})
export class ProdutoComponent implements OnInit {

  public produtoForm!: FormGroup
  public produtoSelecionado: Produto | null = null;
  public modo: 'post' | 'put' = 'post';
  public titulo = 'Produtos'

  public produtos! : Produto[];

  constructor(private fb: FormBuilder,
              private produtoService: ProdutoService
  ) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.criarForm();
    this.carregarProdutos();
  }

  carregarProdutos() {
    this.produtoService.getAll().subscribe({
      next: (prod: Produto[]) => {
        this.produtos = prod;
      },
      error: (erro: any) => {
        console.error(erro);
      },
    })
  }

  criarForm() {
    this.produtoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      quantidade: ['', Validators.required]
    });
  }

  salvarProduto(prod: Produto) {
    (prod.id === 0) ? this.modo = 'post' : this.modo = 'put'

    this.produtoService[this.modo](prod).subscribe({
      next: (prod: Produto) => {
        console.log(prod);
        this.carregarProdutos()
      },
      error: (erro: any) => {
        console.error(erro);
      }
    })
  }

  produtoSubmit() {
    let prod = this.produtoForm.value as Produto;

    console.log("Produto antes do envio:", JSON.stringify(prod))
    this.salvarProduto(prod);
  }

  deletarProduto(id: number) {
    this.produtoService.delete(id).subscribe({
      next: (model: any) => {
        console.log(model);
        this.carregarProdutos();
      },
      error: (erro: any) =>{
        console.error(erro);
      }
    })
  }


  produtoSelect(prod: Produto) {
    this.produtoSelecionado = {id: 0, nome: '', quantidade: 0};
    this.produtoForm.patchValue(prod); //Faz o match das informações
  }

  produtoNovo() {
    this.produtoSelecionado = new Produto(0, '', 0);
    this.produtoForm.patchValue(this.produtoSelecionado); //Faz o match das informações
  }

  voltar() {
    this.produtoSelecionado = null; //Voltar para a página definida
  }

}
