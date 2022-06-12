const baseUrl = "http://localhost:5066/api/Cooler"

Vue.createApp({
    data() {
        return {
            coolers: [],
            singleCooler: null,
            idToGetBy: null,
            deleteId: null,
            deleteMessage: "",
            addData: { capacityOfBottles: null, temp: null, bottlesInStorage: null },
            updateData: { coolerId: null, capacityOfBottles: null, temp: null, bottlesInStorage: null},
            addMessage: "",
            updateMessage: ""
        }
    },
    created(){
        this.getAllCoolers()
    },

    methods: {
        

        async helperGetAndShow(url) {
            try {
                const response = await axios.get(url)
                this.coolers = await response.data
            } catch (ex) {
                alert(ex.message) 
            }
        },
        
        getAllCoolers() {
            this.helperGetAndShow(baseUrl)
        },

        async getById(id) {
            const url = baseUrl + "/" + id
            try {
                const response = await axios.get(url)
                this.singleCooler = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },

        async AddWine(id) {
            const url = baseUrl + "/" + id + "/AddWine"
            try {
                const response = await axios.get(url)
                this.addMessage = "response " + response.status + " " + response.statusText
            } catch (ex) {
                alert(ex.message)
            }
            this.getAllCoolers()
        },

        async deleteCooler(deleteId) {
            const url = baseUrl + "/" + deleteId
            try {
                response = await axios.delete(url)
                this.deleteMessage = response.status + " " + response.statusText
                this.getAllCoolers()
            } catch (ex) {
                alert(ex.message)
            }
        },

        async add() {
            try {
                response = await axios.post(baseUrl, this.addData)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.getAllCoolers()
            } catch (ex) {
                alert(ex.message)
            }
        },

        async update() {
            const url = baseUrl + "/" + this.updateData.coolerId
            try {
                response = await axios.put(url, this.updateData)
                this.updateMessage = "response " + response.status + " " + response.statusText
                this.getAllCoolers()
            } catch (ex) {
                alert(ex.message)
            }
        },

        sortById() {
            this.coolers.sort((cooler1, cooler2) => cooler1.coolerId - cooler2.coolerId)
        },

        sortByCapacityOfBottlesAscending() {
            this.coolers.sort((cooler1, cooler2) => cooler1.capacityOfBottles - cooler2.capacityOfBottles)
        },
        sortByCapacityOfBottlesDescending() {
            this.coolers.sort((cooler1, cooler2) => cooler2.capacityOfBottles - cooler1.capacityOfBottles)
        },
    },
    
    
}).mount("#app")