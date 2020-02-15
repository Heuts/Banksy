import { Component, OnInit } from "@angular/core";
import { MutationService } from "src/app/services/mutation.service";
import { MutationDto } from "src/app/dtos/mutation.dto";
import { Router } from "@angular/router";
import { Observable, timer, merge, combineLatest } from "rxjs";
import { mapTo, takeUntil } from "rxjs/operators";
import { CategoryDto } from "src/app/dtos/category.dto";

@Component({
  selector: "app-mutation-overview",
  templateUrl: "./mutation-overview.component.html",
  styleUrls: ["./mutation-overview.component.css"]
})
export class MutationOverviewComponent implements OnInit {
  mutations: MutationDto[];
  categories: CategoryDto[];
  showSpinner: boolean;
  itemsPerPage: number = 10;
  totalItems: number;
  page: number = 1;
  previousPage: number;

  constructor(private mutationService: MutationService, private route: Router) { }

  ngOnInit(): void {
    this.loadMutations();
    this.getTotalMutations();
    this.getCategories();
  }

  getTotalMutations() {
    this.mutationService
      .getTotalMutations()
      .subscribe(m => this.totalItems = m);
  }

  loadMutations() {
    const miliSecDelayBeforeSpinning = 500;
    const miliSecMinimalSpinningTime = 1000;

    const mutations$: Observable<MutationDto[]> =
      this.mutationService
        .getMutationsByPageAndSize(
          this.page,
          this.itemsPerPage,
        );

    const showLoadingIndicator$ = merge(
      timer(miliSecDelayBeforeSpinning).pipe(mapTo(true), takeUntil(mutations$)),
      combineLatest(mutations$, timer(miliSecMinimalSpinningTime)).pipe(mapTo(false)));

    mutations$.subscribe(mutations => {
      this.mutations = mutations;
    });

    showLoadingIndicator$.subscribe(isLoading => {
      this.showSpinner = isLoading;
    });
  }

  getCategories() {
    this.mutationService.getCategories()
      .subscribe(c => {
        this.categories = c;
      });
  }

  loadPage(page) {
    if (page !== this.previousPage) {
      this.previousPage = page;
      this.loadMutations();
    }
  }

  sliceDescription(str: string) {
    const maxLength: number = 100;
    if (str.length > maxLength) {
      return str.slice(0, maxLength).trim() + '...';
    } else {
      return str;
    }
  }

  sliceName(str: string) {
    const maxLength: number = 25;
    if (str.length > maxLength) {
      return str.slice(0, maxLength).trim() + '...';
    } else {
      return str;
    }
  }

  navigateToMutationDetail(id: number) {
    this.route.navigateByUrl(`mutation-detail/` + id);
  }
}
