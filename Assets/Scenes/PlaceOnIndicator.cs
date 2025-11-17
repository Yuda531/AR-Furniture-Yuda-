using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnIndicator : MonoBehaviour
{
    [SerializeField]
    GameObject placementIndicator;

    [SerializeField]
    private GameObject rotateRightButton;

    [SerializeField]
    private GameObject rotateLeftButton;

    // Variabel untuk menyimpan objek yang sedang di-preview
    private GameObject objectToPlace;

    public float rotationStep = 15.0f;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        placementIndicator.SetActive(false);

        rotateRightButton.SetActive(false);
        rotateLeftButton.SetActive(false);
    }

    private void Update()
    {
        // Logika untuk placementIndicator (tetap sama)
        if (aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);

            if (!placementIndicator.activeInHierarchy)
                placementIndicator.SetActive(true);

            // Jika kita punya objek preview, gerakkan posisinya (TAPI JANGAN ROTASINYA)
            if (objectToPlace != null)
            {
                if (!objectToPlace.activeInHierarchy)
                    objectToPlace.SetActive(true); // Tampilkan jika tersembunyi

                objectToPlace.transform.position = hitPose.position;
                // Kita tidak mengatur rotasi di sini agar rotasi manual dari user tidak ter-reset
            }
        }
        else
        {
            placementIndicator.SetActive(false);

            // Jika plane hilang, sembunyikan juga objek preview-nya
            if (objectToPlace != null)
                objectToPlace.SetActive(false);
        }
    }

    // --- FUNGSI UNTUK TOMBOL FURNITURE ---
    public void SelectObjectToPlace(GameObject prefabToSpawn)
    {
        // Jika sebelumnya sudah ada objek preview, hancurkan dulu
        if (objectToPlace != null)
        {
            Destroy(objectToPlace);
        }

        // Cek apakah indicator aktif (ada bidang datar terdeteksi)
        if (placementIndicator.activeInHierarchy)
        {
            // Spawn prefab di posisi indicator sebagai objek preview
            objectToPlace = Instantiate(prefabToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
        // Opsional: jika plane belum ada, spawn tapi sembunyikan
        else
        {
            objectToPlace = Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
            objectToPlace.SetActive(false);
        }

        rotateRightButton.SetActive(true);
        rotateLeftButton.SetActive(true);
    }

    // --- FUNGSI UNTUK TOMBOL ROTASI ---
    public void RotateRight()
    {
        if (objectToPlace != null)
        {
            // Putar objek 15 derajat searah jarum jam (mengelilingi sumbu Y)
            objectToPlace.transform.Rotate(Vector3.up, rotationStep);
        }
    }

    public void RotateLeft()
    {
        if (objectToPlace != null)
        {
            // Putar objek 15 derajat berlawanan jarum jam (mengelilingi sumbu Y)
            objectToPlace.transform.Rotate(Vector3.up, -rotationStep);
        }
    }

    // --- FUNGSI UNTUK TOMBOL Finish ---
    public void ConfirmPlacement()
    {
        // Cek apakah ada objek preview
        if (objectToPlace == null)
            return; // Tidak ada yang perlu dikonfirmasi

        // Tambahkan objek yang baru di-spawn ke dalam list
        spawnedObjects.Add(objectToPlace);

        // Kosongkan variabel objectToPlace agar tidak lagi di-update posisinya
        objectToPlace = null;

        rotateRightButton.SetActive(false);
        rotateLeftButton.SetActive(false);
        // ---------------------------------
    }

    // --- FUNGSI UNTUK TOMBOL Delete ---
    public void DeleteLastObject()
    {
        if (spawnedObjects.Count > 0)
        {
            int lastIndex = spawnedObjects.Count - 1;
            GameObject lastObject = spawnedObjects[lastIndex];
            spawnedObjects.RemoveAt(lastIndex);
            Destroy(lastObject);
        }
    }
}