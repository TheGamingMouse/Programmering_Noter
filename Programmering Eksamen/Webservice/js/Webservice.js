const app = Vue.createApp({
    data() {
        return {
            data: null,
            id: null,
            stockLevel: null,
            title: null,
            year: null,
            inStock: null
        };
    },
    methods: {
        get() {
            axios.get('http://localhost:5045/TestClasses')
            .then(function(response) {
                this.data = response;
            });
        },
        getById() {
            axios.get('http://localhost:5045/TestClasses/' + id)
            .then(function(response) {
                this.data = response;
            });
        },
        getLowStock() {
            axios.get('http://localhost:5045/TestClasses/stock?StockLevel=' + stockLevel)
            .then(function(response) {
                this.data = response;
            });
        },
        post() {
            const testClass = {
                jTitle: this.jTitleitle = title,
                jYear: this.jYear = year,
                jInStock: this.jInStock = inStock
            }
            axios.post('http://localhost:5045/TestClasses', testClass)
            .then(response => this.testClassId = response.data.id)
        },
        put() {
            const testClass = {
                jTitle: this.jTitleitle = title,
                jYear: this.jYear = year,
                jInStock: this.jInStock = inStock
            }
            axios.post('http://localhost:5045/TestClasses/' + id, testClass)
            .then(response => this.testClassId = response.data.id)
        },
        delete() {
            axios.delete('http://localhost:5045/TestClasses/' + id)
            .then(function(response) {
                this.data = response;
            });
        }
    }
})