// Bootstrap toast
if (document.getElementById('liveToast') != null) {
    const toastLiveExample = document.getElementById('liveToast')

    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)

    toastBootstrap.show()
}

// Add Ingredient input fields
if (document.querySelector(".ingredients-container") != null) {
    const ingredientsContainer = document.querySelector(".ingredients-container");
    const addIngredientButton = document.querySelector("#add-ingredient")
    const removeIngredientButton = document.querySelector("#remove-ingredient")
    const ingredients = ingredientsContainer.children;

    let count = 0;

    // Displays ingredients that have content in them
    for (let i = 0; i < ingredients.length; i++) {
        if (ingredients[count].querySelector("input").value && ingredients[count].classList.contains("d-none")) {
            ingredients[count].classList.remove("d-none");
            count++;

            if (count > 0 && removeIngredientButton.classList.contains("d-none")) {
                removeIngredientButton.classList.remove("d-none");
            }
        }
    }

    addIngredientButton.addEventListener("click", () => {
        if (count < ingredients.length && ingredients[count].classList.contains("d-none")) {
            ingredients[count].classList.remove("d-none");
            count++;

            if (count > 0 && removeIngredientButton.classList.contains("d-none")) {
                removeIngredientButton.classList.remove("d-none");
            }
        }
    });

    removeIngredientButton.addEventListener("click", () => {
        if ((count - 1) >= 0 && !(ingredients[count - 1].classList.contains("d-none"))) {
            count--
            ingredients[count].children[1].value = "";
            ingredients[count].classList.add("d-none");

            if (count < 1 && !removeIngredientButton.classList.contains("d-none")) {
                removeIngredientButton.classList.add("d-none");
            }
        }
    });
}

// Add Steps input fields
if (document.querySelector(".steps-container") != null) {
    const stepsContainer = document.querySelector(".steps-container");
    const addStepButton = document.querySelector("#add-step")
    const removeStepButton = document.querySelector("#remove-step")
    const steps = stepsContainer.children;

    let count = 0;

    // Displays steps that have content in them
    for (let i = 0; i < steps.length; i++) {
        console.log(steps[count]);
        if (steps[count].querySelector("textarea").value && steps[count].classList.contains("d-none")) {
            steps[count].classList.remove("d-none");
            count++;

            if (count > 0 && removeStepButton.classList.contains("d-none")) {
                removeStepButton.classList.remove("d-none");
            }
        }
    }

    addStepButton.addEventListener("click", () => {
        if (count < steps.length && steps[count].classList.contains("d-none")) {
            steps[count].classList.remove("d-none");
            count++;

            if (count > 0 && removeStepButton.classList.contains("d-none")) {
                removeStepButton.classList.remove("d-none");
            }
        }
    });

    removeStepButton.addEventListener("click", () => {
        if ((count - 1) >= 0 && !(steps[count - 1].classList.contains("d-none"))) {
            count--
            steps[count].children[1].value = "";
            steps[count].classList.add("d-none");

            if (count < 1 && !removeStepButton.classList.contains("d-none")) {
                removeStepButton.classList.add("d-none");
            }
        }
    });
}
