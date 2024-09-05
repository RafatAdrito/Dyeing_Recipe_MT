import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import {
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { DyeingRecipeService } from './dyeing-recipe.service';
import { Dyeing } from './dyeinginterface';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ReactiveFormsModule,
    InputTextModule,
    TableModule,
    CommonModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [DyeingRecipeService],
})
export class AppComponent {
  fb = inject(NonNullableFormBuilder);

  readonly newForm = this.fb.group({
    customerName: ['', Validators.required],
    color: ['', Validators.required],
    orderNo: ['', Validators.required],
    style: ['', Validators.required],
    fabrication: ['', Validators.required],
    labdipNo: ['', Validators.required],
    tableFields: this.fb.group({
      date: ['', Validators.required],
      batchNo: ['', Validators.required],
      batchQty: ['', Validators.required],
      mcNo: ['', Validators.required],
      workOrderNo: ['', Validators.required],
      yarnLotNo: ['', Validators.required],
      fType: ['', Validators.required],
      dyeingProcess: ['', Validators.required],
      remarks: ['', Validators.required],
    }),
  });

  readonly rows = signal<Dyeing[]>([]);
  headings = [
    'Date',
    'Batch No',
    'Batch Qty',
    'M/C No',
    'Work Order No',
    'Yarn Lot No',
    'F/type',
    'Dyeing Process',
    'Remarks',
    'Actions',
  ];
  wantToUpdate = signal(false);
  fetchedId: number;
  constructor(private dyeingRecipe: DyeingRecipeService) {}

  ngOnInit() {
    this.getRecipe().then((data) => this.rows.set(data));
  }

  async getRecipe() {
    return await this.dyeingRecipe.getRecipe();
  }

  async saveData() {
    await this.dyeingRecipe.saveRecipeData(
      this.newForm.controls.tableFields.value
    );
    this.getRecipe().then((data) => this.rows.set(data));
    this.newForm.controls.tableFields.reset();
  }

  async deleteRec(id: number) {
    await this.dyeingRecipe.deleteRecipeData(id);
    this.getRecipe().then((data) => this.rows.set(data));
  }

  async updateRec(id: number) {
    this.wantToUpdate.set(true);
    const result = this.rows().find((elem) => elem.id === id);
    if (result) {
      this.fetchedId = result.id;
      this.newForm.controls.tableFields.patchValue({
        date: result.date,
        batchNo: result.batchNo,
        batchQty: result.batchQty,
        mcNo: result.mcNo,
        workOrderNo: result.workOrderNo,
        yarnLotNo: result.yarnLotNo,
        fType: result.fType,
        dyeingProcess: result.dyeingProcess,
        remarks: result.remarks,
      });
    }
  }

  async finalupdate(fetchedId: number) {
    await this.dyeingRecipe.updateRecipeById(
      this.newForm.controls.tableFields.value,
      fetchedId
    );
    this.getRecipe().then((data) => this.rows.set(data));
    this.newForm.reset();
    this.wantToUpdate.set(false);
  }
}
