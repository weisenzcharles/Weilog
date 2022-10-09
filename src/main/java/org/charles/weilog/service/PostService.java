package org.charles.weilog.service;

import org.charles.weilog.domain.Post;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface PostService {
//    Page<Post> listPost(Pageable pageable, PostQuery post);

    Page<Post> listPost(Pageable pageable);

    Page<Post> listPost(Pageable pageable, String query);

    boolean add(Post tag);

    boolean remove(Long id);

    boolean update(Post tag);

    Post query(Long id);

    List<Post> query(String title, int pageIndex, int pageSize);

    List<Post> query(int pageIndex, int pageSize);
}