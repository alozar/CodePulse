import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;
  private addCategorySubsciption? : Subscription;

  constructor(private categoryService: CategoryService) {
    this.model = {
      name: '',
      urlHandle: ''
    }
  }

  onFormSubmit() {
    this.addCategorySubsciption = this.categoryService
      .addCategory(this.model)
      .subscribe({
        next: (response) => {
          console.log({mes:"This was successful!!!", response});
        },
        error: (error) => {

        }
      });
  }

  ngOnDestroy(): void {
    this.addCategorySubsciption?.unsubscribe();
  }
}
