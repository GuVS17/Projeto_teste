import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../services/Produto.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Produto } from '../../models/Produto';
import { PaginatedResult, Pagination } from '../../models/Pagination';

@Component({
  selector: 'app-Produto',
  templateUrl: './Produto.component.html',
  styleUrls: ['./Produto.component.css'],
  standalone: false,
})
export class ProdutoComponent implements OnInit {

  public produtoForm!: FormGroup
  public produtoSelecionado?: Produto;
  public modo: 'post' | 'put' = 'post';
  public titulo = 'Produtos'
  pagination: Pagination;

  public produtos! : Produto[];

  constructor(private fb: FormBuilder,
              private produtoService: ProdutoService,
  ) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.pagination = { currentPage: 1, itemsPerPage: 10 } as Pagination;
    this.criarForm();
    this.carregarProdutos();
  }

  carregarProdutos() {
    this.produtoService.getAll(this.pagination.currentPage, this.pagination.itemsPerPage).subscribe({
      next: (prod: PaginatedResult<Produto[]>) => {
        this.produtos = prod.result;
        this.pagination = prod.pagination;
      },
      error: (erro: any) => {
        console.error(erro);
      },
    })
  }

  pageChanged(event: any): void {
    this.pagination.currentPage= event.page;
    this.carregarProdutos();
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
    this.produtoSelecionado = prod
    this.produtoForm.patchValue(prod); //Faz o match das informações
  }

  produtoNovo() {
    this.produtoSelecionado = new Produto(0, '', 0);
    this.produtoForm.patchValue(this.produtoSelecionado); //Faz o match das informações
  }

  voltar() {
    this.produtoSelecionado = undefined; //Voltar para a página definida
  }

}
